using Pathfinding;
using UnityEngine;

public class AggroActivator : MonoBehaviour
{
    [SerializeField] private EnemyMovement enemyMovement;
    [SerializeField] private AIPath enemyPath;
    public AIDestinationSetter destinationSetter;

    private void Start()
    {
        destinationSetter.target = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destinationSetter != null 
            && destinationSetter.target == null 
            && collision.CompareTag(PetConstants.PetTag))
        {
            AggroEnemy();
        }
    }

    public void AggroEnemy()
    {
        destinationSetter.target = PlayerManager.Pet.transform;
        enemyPath.enabled = true;
        enemyPath.maxSpeed = enemyMovement.MoveSpeed;
    }
}
