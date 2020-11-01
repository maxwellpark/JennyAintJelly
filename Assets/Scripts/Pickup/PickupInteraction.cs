using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// remember to trigger animation on collision 
public class PickupInteraction : MonoBehaviour
{
    public PickupData pickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Debug.Log("Pickup collision"); 
            pickup.TriggerPickup();
            Destroy(gameObject);

        }
    }
}
