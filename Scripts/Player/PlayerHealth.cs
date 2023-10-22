using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    [HideInInspector]
    public int health;

    public int maxArmor = 100;
    private int armor;

    [SerializeField] GameObject deathMenu;

    [Header("Sounds")]
    [SerializeField] AudioSource hurtSound;
    [SerializeField] AudioSource healSound;
    [SerializeField] AudioSource armorSound;

    void Start()
    {
        deathMenu.SetActive(false);
        health = maxHealth;
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DamagePlayer(30);
            Debug.Log("Player Acertado");
        }
    }

    public void DamagePlayer(int damage)
    {
        hurtSound.Play();
        //se tem armadura, acerta nela
        if (armor > 0)
        {
            if (armor >= damage)
            {
                //se tem armadura suficiente para aguentar todo o dano, só acerta na armadura
                armor -= damage;
            }
            else if (armor < damage)
            {
                //se não tem armadura suficiente para aguentar todo o dano, acerta na armadura e o resto na vida
                int remainigDamage;
                remainigDamage = damage - armor;

                armor = 0;

                health -= remainigDamage;
            }
        }
        else
        {
            //se não tem armadura, acerta na vida
            health -= damage;
        }

        if (health <= 0)
        {
            //player morto
            Time.timeScale = 0f;
            GetComponent<MouseLook>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            deathMenu.SetActive(true);
            Debug.Log("Player Morto");
            
        }
        CanvasManager.Instance.UpdateHealth(health);
        CanvasManager.Instance.UpdateArmor(armor);
    }

    public void GiveHealth(int amount, GameObject pickup)
    {
        healSound.Play();
        if (health < maxHealth)
        {
            health += amount;
            Destroy(pickup);
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }
        CanvasManager.Instance.UpdateHealth(health);
    }

    public void GiveArmor(int amount, GameObject pickup)
    {
        if (armor < maxArmor)
        {
            armor += amount;
            Destroy(pickup);
        }

        if (armor > maxArmor)
        {
            armor = maxArmor;
        }
        CanvasManager.Instance.UpdateArmor(armor);
    }
}

    
