using Pathfinding;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    public static event Action onEnemyDeath; 

    private EnemyData enemyData;

    private AIPath aiPath;
    private AIDestinationSetter destinationSetter;

    private void Start()
    {
        enemyData = GetComponent<EnemyData>();

        aiPath = GetComponent<AIPath>();
        aiPath.maxSpeed = enemyData.movementSpeed;
        aiPath.enableRotation = false;

        // Start pathing towards player if in range 
        aiPath.enabled = IsInAggroRange();

        destinationSetter = GetComponent<AIDestinationSetter>();
        destinationSetter.target = PlayerData.petObject.transform;
    }

    private bool IsInAggroRange()
    {
        if (Vector3.Distance(transform.position, PlayerData.playerObject.transform.position) <= enemyData.aggroRange)
        {
            return true;
        }
        return false;
    }

    private void Update()
    {
        if (!aiPath.enabled)
        {
            aiPath.enabled = IsInAggroRange();
        }
    }

    public void TakeDamage()
    {
        enemyData.hitpoints -= PlayerData.damage;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.transform.tag)
        {
            case "Pet":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
                    
            case "Projectile":
                TakeDamage();
                Destroy(other.gameObject);
                break;

            // Add more weapon debuffs here if needed
        }

        if (enemyData.hitpoints <= 0)
        {
            Destroy(gameObject);
            onEnemyDeath?.Invoke();
        }
    }
}