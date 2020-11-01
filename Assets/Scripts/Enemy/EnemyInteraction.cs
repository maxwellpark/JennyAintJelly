using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    private EnemyData enemyData;

    private float timer;
    private float timerReset = 30f;
    private float aggroRange = 60f;

    //BloodEffect bloodEffect;
    //public GameObject blood; 

    void Start()
    {
        enemyData = GetComponent<EnemyData>();
        //bloodEffect = GetComponent<BloodEffect>(); 
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, PlayerData.playerObject.transform.position) <= aggroRange)
        {
            // TODO: 
            // start pathing towards player if within proximity 
            // can we do this with events or something else - so we don't need to keep checking aggrorange 
        }
    }

    public void TakeDamage()
    {
        enemyData.hitpoints -= PlayerData.damage;
        // enemy hit effect here 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.transform.tag)
        {
            case "Pet":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "Projectile":
                TakeDamage();
                Destroy(other.gameObject);
                break;

            case "SlowProjectile":
                TakeDamage();
                enemyData.movementSpeed -= PlayerData.slowAmount;
                Destroy(other.gameObject);
                break;

            case "SnareProjectile":
                TakeDamage();
                enemyData.movementSpeed = 0f;
                // remember to start timer
                // and play animation/add static sprite 

                Destroy(other.gameObject);
                break;

            case "Wall":
                // Unstick method here?
                break;
        }

        if (enemyData.hitpoints <= 0)
        {
            //bloodEffect.CreateBlood(); 
            Destroy(gameObject);
        }
    }
}