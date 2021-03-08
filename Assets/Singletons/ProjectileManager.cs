﻿using UnityEngine;

public class ProjectileManager : MonoBehaviour, ISingleton
{
    public static ProjectileManager Instance { get; private set; }

    private static GameObject currentProjectilePrefab;
    [SerializeField] private GameObject defaultProjectilePrefab;

    private static AudioSource projectileAudio;
    [SerializeField] private AudioClip defaultProjectileSound;

    // Dictates the projectile spawn position
    private GameObject gunBarrel;

    public static float CurrentRateOfFire { get; set; }
    public static float CurrentDamage { get; set; }
    private float timer;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        GameManager.OnLevelTransition += SetStartingValues;
    }

    private void Start()
    {
        projectileAudio = GetComponent<AudioSource>();
        gunBarrel = GameObject.FindGameObjectWithTag(ProjectileConstants.GunBarrelTag);
        SetStartingValues();
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
            return;
        }

        if (Input.GetButtonDown(ProjectileConstants.FireButton))
        {
            FireProjectile();
            timer = CurrentRateOfFire;
        }
    }

    public void FireProjectile()
    {
        GameObject newProjectile = Instantiate(
            currentProjectilePrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        
        Rigidbody2D rigidBody = newProjectile.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(gunBarrel.transform.up * ProjectileConstants.MuzzleVelocity, ForceMode2D.Impulse);

        // Make bullets pass through player 
        Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), PlayerManager.PlayerCollider);

        AudioManager.Instance.ProjectileAudio.Play();
    }

    public static void SetCurrentProjectile(GameObject projectilePrefab, AudioClip projectileSound)
    {
        currentProjectilePrefab = projectilePrefab;
        AudioManager.Instance.ProjectileAudio.clip = projectileSound;
    }

    public void SetStartingValues()
    {
        currentProjectilePrefab = defaultProjectilePrefab;
        AudioManager.Instance.ProjectileAudio.clip = defaultProjectileSound;
        CurrentRateOfFire = ProjectileConstants.DefaultRateOfFire;
    }
}
