using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource LaserGunSound;

    private float weaponCooldown = 0.5f;
    private float lastShotTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (Time.time - lastShotTime >= weaponCooldown)
            {
                PlayerShoot();

                lastShotTime = Time.time;
            }
        }
    }

    void PlayerShoot()
    {
        if(LaserGunSound != null)
        {
            LaserGunSound.Play();
        }
        else
        {
            Debug.Log("No audio");
        }
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
