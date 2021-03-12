using Pathfinding;
using UnityEngine;

public class AggroActivator : MonoBehaviour
{
    [SerializeField] private Enemy enemyToAgrro;
    [SerializeField] private AIPath enemyPath;
    [SerializeField] private AIDestinationSetter destinationSetter;

    private void Start()
    {
        destinationSetter.target = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destinationSetter.target is null && collision.CompareTag(PetConstants.PetTag))
        {
            destinationSetter.target = PlayerManager.Pet.transform;
            enemyPath.enabled = true;
            enemyPath.maxSpeed = enemyToAgrro.MoveSpeed;
        }
    }
}
