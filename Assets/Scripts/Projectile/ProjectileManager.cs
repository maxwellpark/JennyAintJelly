using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    Standard, Dual, Tri, Slow, Medium, Blast
}

public class ProjectileManager : MonoBehaviour
{
    public GameObject startingWeaponPrefab;
    public GameObject dualShotPrefab;
    public GameObject triShotPrefab;
    public GameObject slowProjectilePrefab;
    public GameObject snakeShotPrefab;
    public GameObject theMediumOnePrefab;
    public GameObject theBigOnePrefab;

    public static GameObject gunBarrel;
    public static GameObject currentWeaponPrefab;

    private AudioSource sfx;

    public static float weaponDuration;
    public static bool weaponActive;

    public float muzzleVelocity = 10f;
    public float spreadDistance = 2f;


    void Start()
    {
        gunBarrel = GameObject.Find("GunBarrel");
        currentWeaponPrefab = startingWeaponPrefab;

        PickupData.onWeaponPickup += SetProjectilePrefab;

        //sfx = GameObject.Find("SoundFXManager").GetComponent<AudioSource>();
        //sfx.loop = false;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //sfx.Play();
            FireProjectile(currentWeaponPrefab);

        }

        // debug this 
        if (weaponActive)
        {
            if (weaponDuration <= 0)
            {
                weaponActive = false;
                currentWeaponPrefab = startingWeaponPrefab;
                weaponDuration = 0f;
            }
            weaponDuration--;
        }

    }

    public void FireProjectile(GameObject prefab)
    {
        GameObject newProjectile = Instantiate(prefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();

        // Make bullets pass through player 
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), PlayerData.playerObject.GetComponent<Collider2D>());

        rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);

        // ncap 
        if (prefab == dualShotPrefab)
        {
            GameObject secondProjectile = Instantiate(
                prefab, gunBarrel.transform.position + new Vector3(spreadDistance, 0f, 0f), gunBarrel.transform.rotation);
            Physics2D.IgnoreCollision(secondProjectile.GetComponent<Collider2D>(), PlayerData.playerObject.GetComponent<Collider2D>());
            rb = secondProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);
        }
    }

    public void SetProjectilePrefab(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.Standard:
                currentWeaponPrefab = startingWeaponPrefab;
                break;
            case WeaponType.Dual:
                currentWeaponPrefab = dualShotPrefab;
                break;
            case WeaponType.Tri:
                currentWeaponPrefab = triShotPrefab;
                break;
            case WeaponType.Slow:
                currentWeaponPrefab = slowProjectilePrefab;
                break;
            case WeaponType.Medium:
                currentWeaponPrefab = theMediumOnePrefab;
                break;
            case WeaponType.Blast:
                currentWeaponPrefab = theBigOnePrefab;
                break;
        }
    }
}
