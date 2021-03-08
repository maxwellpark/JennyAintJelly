using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float timer = ProjectileConstants.DecayTime;

    private void Update()
    {
        timer--;
        
        // Destroy the object after the timer has elapsed
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
