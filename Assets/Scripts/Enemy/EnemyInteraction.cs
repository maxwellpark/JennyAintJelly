using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    public GameObject playerObject;
    public PlayerData playerData;
    EnemyData enemyData;

    Vector3 currentPosition;
    Vector3 lastPosition;
    float unstickDistance = 0.75f; 
    bool stuck;

    float timer;
    float timerReset = 30f; 

    float aggroRange = 60f;

    //BloodEffect bloodEffect;
    //public GameObject blood; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        playerData = playerObject.GetComponent<PlayerData>();
        enemyData = GetComponent<EnemyData>();
        //bloodEffect = GetComponent<BloodEffect>(); 
    }

    void Update()
    {
        timer++;
        if (timer >= timerReset)
        {
            timer = 0f; 
            currentPosition = transform.position;

            if (currentPosition == lastPosition)
            {
                UnstickEnemy();
            } 

            // Save last frame's position 
            lastPosition = currentPosition;
        }

        if (Vector3.Distance(transform.position, playerObject.transform.position) <= aggroRange)
        {
            // TODO: 
            // start pathing towards player if within proximity 
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

    void UnstickEnemy()
    {
        // naive solution for now 
        // can encapsulate update method here if needed. 


        // Enemy needs to go left or right 
        if (Mathf.Abs(playerObject.transform.position.x - transform.position.x) >
            Mathf.Abs(playerObject.transform.position.y - transform.position.y))
        {
            if (playerObject.transform.position.x > transform.position.x)
            {
                transform.position += new Vector3(unstickDistance, 0f, 0f);
            }
            else
            {
                transform.position += new Vector3(-unstickDistance, 0f, 0f);
            }
        }
        else
        {
            if (playerObject.transform.position.y > transform.position.y)
            {
                transform.position += new Vector3(0f, unstickDistance, 0f);
            }
            else
            {
                transform.position += new Vector3(-0f, -unstickDistance, 0f);
            }
        }
        //else
        //{
        //    //stuck = false;
        //}
        //while (stuck)
        //{
        //    //do more gradual, iterative repositioning*
        //}
    }
}