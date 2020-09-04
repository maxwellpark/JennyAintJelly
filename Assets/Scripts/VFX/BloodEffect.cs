using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodEffect : MonoBehaviour
{
    public GameObject bloodPrefab;
    GameObject leakedBlood;
    float bloodVelocity;
    float timer = 60f;

    void Update()
    {
        // make a common decay utils method?
        // (for destroying obj after expired)* 
        if (timer <= 0)
        {
            Destroy(leakedBlood);
        }
        timer--;
    }

    public void CreateBlood()
    {
        leakedBlood = Instantiate(bloodPrefab);
        Rigidbody2D rb = bloodPrefab.GetComponent<Rigidbody2D>(); // rb unncessary?  
        rb.AddForce(transform.up * bloodVelocity, ForceMode2D.Impulse);
    }
}
