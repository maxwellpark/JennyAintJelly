using UnityEngine;
using UnityEngine.AI;

public class AggroActivator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PetConstants.PetTag))
        {
            Debug.Log("Aggro collision");

            agent.SetDestination(PlayerManager.PetPosition);
            Debug.Log("New destination: " + agent.destination);
        }
    }
}
