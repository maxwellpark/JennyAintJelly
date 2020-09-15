using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyInteraction : MonoBehaviour
{
    public static event Action onEnemyDeath;

    public GameObject playerObject;
    public PlayerData playerData;

    private EnemyData enemyData;
    private Transform petTransform;  

    private Vector3 currentPosition;
    private Vector3 lastPosition;
    private float unstickDistance = 0.75f;
    private bool stuck;


    private float timer;
    private float timerReset = 30f;

    //BloodEffect bloodEffect;
    //public GameObject blood; 

    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player"); // refactor this later 
        playerData = playerObject.GetComponent<PlayerData>();
        enemyData = GetComponent<EnemyData>();
        petTransform = enemyData.petTransform;
        //bloodEffect = GetComponent<BloodEffect>(); 
    }

    void Update()
    {
        // could change this to Vector.Distance 
        // which one is more performant? 
        if ((transform.position - petTransform.position).magnitude <= enemyData.aggroRange)
        {
            enemyData.inPursuit = true;
            enemyData.destinationSetter.target = petTransform;
        }

        timer++;
        if (timer >= timerReset)
        {
            timer = 0f; 
            currentPosition = transform.position;

            if (currentPosition == lastPosition)
            {
                //UnstickEnemy();
            } 

            // Save last frame's position 
            lastPosition = currentPosition;
        }

        //if (Vector3.Distance(transform.position, playerObject.transform.position) <= aggroRange)
        //{
        //    // TODO: 
        //    // start pathing towards player if within proximity 
        //}


    }

    public void TakeDamage()
    {
        enemyData.hitpoints -= PlayerData.damage;
        // enemy hit effect here 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // encapulsate this...
        switch (other.transform.tag)
        {
            case "Pet":
                // should trigger a death scene of some sort here
                // before reloading checkpoint 
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "Projectile":
                TakeDamage();
                Destroy(other.gameObject);
                onEnemyDeath?.Invoke();
                break;

            // nest the other projectiles inside the above case
            // * 
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