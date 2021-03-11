using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    
    [SerializeField] private float moveSpeed;

    public virtual void CatchPet()
    {
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
        //if (collision.CompareTag(PetConstants.PetTag))
        //{
        //    CatchPet();
        //}
        //else if (collision.CompareTag(ProjectileConstants.ProjectileTag))
        //{
        //    TakeDamage();
        //}
    }
}
