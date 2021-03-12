using Pathfinding;
using UnityEngine;

public class AggroActivator : MonoBehaviour
{
    private AIPath path;
    private AIDestinationSetter destinationSetter;

    private void Start()
    {
        path = GetComponentInParent<AIPath>();
        destinationSetter = GetComponentInParent<AIDestinationSetter>();
        destinationSetter.target = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (destinationSetter.target is null && collision.CompareTag(PetConstants.PetTag))
        {
            Debug.Log("Aggro collision");

            destinationSetter.target = PlayerManager.PetTransform;
            path.enabled = true;
            path.maxSpeed = 10;
        }
    }

    private void LogAI()
    {
        Debug.Log("Can move = " + path.canMove);
        Debug.Log("Is stopped = " + path.isStopped);
    }
}
