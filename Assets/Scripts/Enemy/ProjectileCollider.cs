using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    [SerializeField] private Enemy enemyToCheck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ProjectileConstants.ProjectileTag))
        {
            enemyToCheck.TakeDamage();

            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            ProjectileManager.HaltProjectile(projectile);
        }
    }
}
