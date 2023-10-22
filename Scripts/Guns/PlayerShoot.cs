using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] GunData gunData;

    public static Action shootInput;
    public static Action reloadInput;

    [SerializeField] private KeyCode reloadKey = KeyCode.R;

    public Animator weaponAnim;

    void Update()
    {
        if(Input.GetMouseButton(0) && gunData.currentAmmo > 0 && gunData.reloading == false && Time.deltaTime != 0f)
        {
            weaponAnim.SetTrigger("Shooting");
            shootInput?.Invoke();
        }
        else
            weaponAnim.ResetTrigger("Shooting");

        if (Input.GetKeyDown(reloadKey) && gunData.currentAmmo != gunData.magSize && Time.deltaTime != 0f && gunData.ammoAmount != 0)
        {
            weaponAnim.SetTrigger("Reloading");
            reloadInput?.Invoke();
        }
    }
}
