using UnityEngine;

public class ProjectileCollider : MonoBehaviour
{
    [SerializeField] private Enemy enemyToCheck;
    [SerializeField] private AggroActivator aggroActivator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ProjectileConstants.ProjectileTag))
        {
            Projectile projectile = collision.gameObject.GetComponent<Projectile>();
            enemyToCheck.TakeDamage(projectile);

            // Aggro the enemy if they git hit by a projectile
            if (aggroActivator.destinationSetter != null 
                && aggroActivator.destinationSetter.target == null)
            {
                aggroActivator.AggroEnemy();
            }
        }
        else if (collision.CompareTag(ProjectileConstants.CrosshairTag))
        {
            ProjectileManager.Crosshair.SetCursorSprite(isOnTarget: true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(ProjectileConstants.CrosshairTag))
        {
            ProjectileManager.Crosshair.SetCursorSprite(isOnTarget: false);
        }
    }
}
