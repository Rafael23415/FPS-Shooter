using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] GunData gunData;
    [SerializeField] Transform cam;

    [Header("Sound Effects")]
    [SerializeField] AudioSource shotSound;
    [SerializeField] AudioSource reloadSound;

    float timeSinceLastShoot;

    int ammoNeeded;

    private void Start()
    {
        ammoNeeded = gunData.magSize - gunData.currentAmmo;
        gunData.ammoAmount = 30;
        gunData.currentAmmo = gunData.magSize;
        PlayerShoot.shootInput += Shoot;
        PlayerShoot.reloadInput += StartReload;
        CanvasManager.Instance.UpdateAmmo(gunData.currentAmmo);
    }

    private void OnDisable() => gunData.reloading = false;

    public void StartReload()
    {
        if(!gunData.reloading && this.gameObject.activeSelf)
            StartCoroutine(Reload());
    }

    private IEnumerator Reload()
    {
        reloadSound.Play();
        gunData.reloading = true;
        yield return new WaitForSeconds(gunData.reloadTime);

        ammoNeeded = gunData.magSize - gunData.currentAmmo;
        if (gunData.ammoAmount >= ammoNeeded)
        {
            gunData.currentAmmo += ammoNeeded;
            gunData.ammoAmount -= ammoNeeded;
        }
        else 
        {
            gunData.currentAmmo += gunData.ammoAmount;
            gunData.ammoAmount = 0;
        }

        gunData.reloading = false;
        reloadSound.Stop();
    }

    private bool CanShoot() => !gunData.reloading && timeSinceLastShoot > 1f / (gunData.fireRate / 60f);

    private void Shoot()
    {
        if(gunData.currentAmmo > 0)
            if(CanShoot())
            {
                shotSound.Play();
                if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hitInfo, gunData.maxDistance))
                { 
                    IDamageable damageable = hitInfo.transform.GetComponent<IDamageable>();
                    damageable?.TakeDamage(gunData.damage);
                }
                gunData.currentAmmo--;
                timeSinceLastShoot = 0;
                OnGunShoot();
            }
    }

    private void Update()
    {
        Debug.Log(ammoNeeded = gunData.magSize - gunData.currentAmmo);

        CanvasManager.Instance.UpdateAmmo(gunData.currentAmmo);
        CanvasManager.Instance.UpdateAmmoAmount(gunData.ammoAmount);

        timeSinceLastShoot += Time.deltaTime;

        Debug.DrawRay(cam.position, cam.forward * gunData.maxDistance);
    }

    private void OnGunShoot()
    {
        
    }

    public void GiveAmmo(int amount, GameObject pickup)
    {
        gunData.ammoAmount += amount;
        Destroy(pickup);
    }

}