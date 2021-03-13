using UnityEngine;

public class PickupCollider : MonoBehaviour
{
    [SerializeField] private Pickup pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(PlayerConstants.PlayerTag))
        {
            pickup.Claim();
            Destroy(gameObject);
        }
    }
}
