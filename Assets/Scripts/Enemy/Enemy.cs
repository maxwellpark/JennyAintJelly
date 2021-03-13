using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void CatchPet()
    {
        GameManager.CurrentState = GameState.GameOver;
        GameManager.ReloadLevel();
    }

    public virtual void TakeDamage(Projectile projectile)
    {
        currentHealth -= ProjectileManager.CurrentDamage;
        if (currentHealth <= 0)
        {
            Die();

            // Stop the projectile moving when the enemy object is destroyed
            ProjectileManager.HaltProjectile(projectile);
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PetConstants.PetTag))
        {
            CatchPet();
        }
    }
}
