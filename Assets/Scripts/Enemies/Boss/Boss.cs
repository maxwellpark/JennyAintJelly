using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private GameObject gunBarrel;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void ShootRocket()
    {
        GameObject newRocket = Instantiate(rocketPrefab, gunBarrel.transform.position, gunBarrel.transform.rotation);
        NavMeshAgent rocketAgent = newRocket.GetComponent<NavMeshAgent>();
        rocketAgent.SetDestination(PlayerManager.PetPosition);
    }
}
