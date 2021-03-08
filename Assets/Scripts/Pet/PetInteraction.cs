using UnityEngine;

public class PetInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.transform.CompareTag("Enemy") || collider.transform.CompareTag("BossProjectile"))
        {
            GameManager.ReloadLevel();
        }
    }
}
