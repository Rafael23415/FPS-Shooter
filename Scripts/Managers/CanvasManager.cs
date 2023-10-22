using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{
    [Header("Text")]
    public TextMeshProUGUI health;
    public TextMeshProUGUI armor;
    public TextMeshPro ammo;
    public TextMeshProUGUI ammoAmount;

    [Header("Health")]
    public Image HealthIndicator;

    public Sprite health1;//bem
    public Sprite health2;//aleijado
    public Sprite health3;//cr�tico
    public Sprite health4;//morto

    [Header("Keys")]
    public GameObject redKey;
    public GameObject blueKey;
    public GameObject greenKey;

    private static CanvasManager _instance;
    public static CanvasManager Instance
    {
        get { return _instance; }
    }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    //para atualizar o UI
    public void UpdateHealth(int healthValue)
    {
        health.text = healthValue.ToString() +"%";
        UpdateHealthIndicator(healthValue);
    }

    public void UpdateArmor(int armorValue)
    {
        armor.text = armorValue.ToString() + "%";
    }

    public void UpdateAmmo(int ammoValue)
    {
        ammo.text = ammoValue.ToString();
    }

    public void UpdateAmmoAmount(int ammoAmountValue)
    {
        ammoAmount.text = ammoAmountValue.ToString();
    }

    public void UpdateHealthIndicator(int healthValue)
    {
        if(healthValue > 66)
        {
            HealthIndicator.sprite = health1;
        }

        if (healthValue < 66 && healthValue >33)
        {
            HealthIndicator.sprite = health2;
        }

        if (healthValue < 33 && healthValue > 0)
        {
            HealthIndicator.sprite = health3;
        }

        if (healthValue <= 0)
        {
            HealthIndicator.sprite = health4;
        }
    }

    public void UpdateKeys(string keyColor)
    {
        if(keyColor == "red")
        {
            redKey.SetActive(true);
        }

        if (keyColor == "blue")
        {
            blueKey.SetActive(true);
        }

        if (keyColor == "green")
        {
            greenKey.SetActive(true);
        }
    }

    public void ClearKeys()
    {
        redKey.SetActive(false);
        blueKey.SetActive(false);
        greenKey.SetActive(false);
    }
}
