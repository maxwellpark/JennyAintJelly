using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject collisionEffect;
    public int damage;
    private float timer = 60f; 
    private int effectDelay = 1;

    private void Update()
    {
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
        timer--;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
