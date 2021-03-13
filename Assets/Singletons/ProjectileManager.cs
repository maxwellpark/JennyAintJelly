using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProjectileManager : MonoBehaviour, ISingleton
{
    public static ProjectileManager Instance { get; private set; }

    private static GameObject currentProjectilePrefab;
    [SerializeField] private GameObject defaultProjectilePrefab;

    [SerializeField] private AudioSource projectileAudio;
    [SerializeField] private AudioClip defaultProjectileSound;

    // Dictates the projectile spawn position
    private GameObject gunBarrel;

    public static Crosshair Crosshair { get; set; }
    public static float CurrentDamage { get; set; }
    public static float CurrentMass { get; set; }
    public static float CurrentRateOfFire { get; set; }
    private bool isWaitingToFire;

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
        Init();
        SceneManager.sceneLoaded += Init;
    }

    public void Init()
    {
        gunBarrel = GameObject.FindGameObjectWithTag(ProjectileConstants.GunBarrelTag);
        Crosshair = GameObject.FindGameObjectWithTag(ProjectileConstants.CrosshairTag)
            .GetComponent<Crosshair>();
        
        SetDefaults();
    }

    // Subscribe this to the SceneManager's sceneLoaded event 
    public void Init(Scene scene, LoadSceneMode mode)
    {
        Init();
    }

    private void Update()
    {
        if (!isWaitingToFire && Input.GetButtonDown(ProjectileConstants.FireButton))
        {
            StartCoroutine(FireProjectile());
        }
    }

    private IEnumerator FireProjectile()
    {
        if (gunBarrel != null && currentProjectilePrefab != null)
        {
            isWaitingToFire = true;
            GameObject newProjectile = Instantiate(
                currentProjectilePrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        
            Rigidbody2D rigidBody = newProjectile.GetComponent<Rigidbody2D>();
            rigidBody.mass = CurrentMass;
            rigidBody.AddForce(gunBarrel.transform.up * ProjectileConstants.MuzzleVelocity, ForceMode2D.Impulse);

            // Make bullets pass through player 
            Physics2D.IgnoreCollision(newProjectile.GetComponent<Collider2D>(), PlayerManager.PlayerCollider);

            AudioManager.Instance.ProjectileAudio.Play();

            yield return new WaitForSeconds(CurrentRateOfFire);
            isWaitingToFire = false;
        }
    }

    public static void HaltProjectile(Projectile projectile)
    {
        if (projectile != null)
        {
            Rigidbody2D rigidBody = projectile.GetComponent<Rigidbody2D>();
            rigidBody.velocity = Vector2.zero;
            rigidBody.angularVelocity = 0f;
        }
    }

    public static void DestroyAllProjectiles()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag(ProjectileConstants.ProjectileTag);
        foreach (GameObject projectile in projectiles)
        {
            if (projectile != null)
            {
                Destroy(projectile);
            }
        }
    }

    public static void SetCurrentProjectile(GameObject projectilePrefab, AudioClip projectileSound, float projectileMassIncrease = 0)
    {
        if (projectilePrefab != null)
        {
            currentProjectilePrefab = projectilePrefab;
        }
        if (projectileSound != null)
        {
            AudioManager.Instance.ProjectileAudio.clip = projectileSound;
        }
        CurrentMass += projectileMassIncrease;
    }

    public void SetDefaults()
    {
        currentProjectilePrefab = defaultProjectilePrefab;
        AudioManager.Instance.ProjectileAudio.clip = defaultProjectileSound;
        CurrentDamage = ProjectileConstants.DefaultDamage;
        CurrentMass = ProjectileConstants.DefaultMass;
        CurrentRateOfFire = ProjectileConstants.DefaultRateOfFire;
        isWaitingToFire = false;
    }
}
