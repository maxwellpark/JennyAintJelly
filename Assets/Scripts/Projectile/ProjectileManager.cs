using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    standard, dual, tri, slow, medium, blast
}

// weapon scriptable objects not currently working
// as expected
public class ProjectileManager : MonoBehaviour
{
    public GameObject startingWeaponPrefab;
    public GameObject dualShotPrefab;
    public GameObject triShotPrefab;
    public GameObject slowProjectilePrefab;
    public GameObject snakeShotPrefab;
    public GameObject theMediumOnePrefab;
    public GameObject theBigOnePrefab;

    GameObject playerObject;
    public static GameObject gunBarrel;
    public static GameObject currentWeaponPrefab;
    //public static WeaponType weaponType = WeaponType.standard;

    public static float weaponDuration;
    public static bool weaponActive;

    public float muzzleVelocity = 10f;
    public float spreadDistance = 2f;

    AudioSource sfx;


    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        gunBarrel = GameObject.Find("GunBarrel");
        currentWeaponPrefab = startingWeaponPrefab;

        PickupData.onWeaponPickup += SetProjectilePrefab;

        //weaponType = WeaponType.standard;

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
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());

        rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);

        if (prefab == dualShotPrefab)
        {
            GameObject secondProjectile = Instantiate(
                prefab, gunBarrel.transform.position + new Vector3(spreadDistance, 0f, 0f), gunBarrel.transform.rotation);
            Physics2D.IgnoreCollision(secondProjectile.GetComponent<Collider2D>(), playerObject.GetComponent<Collider2D>());
            rb = secondProjectile.GetComponent<Rigidbody2D>();
            rb.AddForce(gunBarrel.transform.up * muzzleVelocity, ForceMode2D.Impulse);
        }
        // stack modifiers?
        // break out wep mods into separate class*
        //if (prefab == snakeShotPrefab)
        //{

        //}
    }

    public void SetProjectilePrefab(WeaponType weaponType)
    {
        switch (weaponType)
        {
            case WeaponType.standard:
                currentWeaponPrefab = startingWeaponPrefab;
                break;
            case WeaponType.dual:
                currentWeaponPrefab = dualShotPrefab;
                break;
            case WeaponType.tri:
                currentWeaponPrefab = triShotPrefab;
                break;
            case WeaponType.slow:
                currentWeaponPrefab = slowProjectilePrefab;
                break;
            case WeaponType.medium:
                currentWeaponPrefab = theMediumOnePrefab;
                break;
            case WeaponType.blast:
                currentWeaponPrefab = theBigOnePrefab;
                break;
        }
    }
}
