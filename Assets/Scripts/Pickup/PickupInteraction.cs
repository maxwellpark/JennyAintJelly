using UnityEngine;

public class PickupInteraction : MonoBehaviour
{
    public Pickup pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(PlayerConstants.PlayerTag))
        {
            Debug.Log("Pickup collision");
            pickup.Claim();
            Destroy(gameObject);
        }
    }
}
