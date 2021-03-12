using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    
    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; }

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public virtual void CatchPet()
    {
        GameManager.CurrentState = GameState.GameOver;
        GameManager.ReloadLevel();
    }

    public virtual void TakeDamage()
    {
        currentHealth -= ProjectileManager.CurrentDamage;
        if (currentHealth <= 0)
        {
            Die();
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
