using Pathfinding;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    // we shouldn't get a pet reference here, 
    // but instead invoke an action that makes
    // a subscriber return the transform 
    // 
    public Transform petTransform;
    public GameObject tileMap;
    public AIPath aiPath;
    public AIDestinationSetter destinationSetter;

    public float movementSpeed;
    public float hitpoints;
    public int damage;

    public bool inPursuit = true; // rename if waves system is scrapped 
    public float aggroRange = 32f;  

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        aiPath.maxSpeed = movementSpeed;
        aiPath.enableRotation = false;
        destinationSetter = GetComponent<AIDestinationSetter>();

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;

        //taggedPet = GameObject.FindGameObjectWithTag("Pet").transform;
        //Debug.Log(taggedPet); 
        //destinationSetter.target = taggedPet;

        //destinationSetter.target = GameObject.FindGameObjectWithTag("Pet").transform;

        if (inPursuit)
        {
            // Only set destination if immediately pursuing 
            destinationSetter.target = petTransform;
        }


        // hp should be dependent on enemy type...
        // also this check shouldn't be required 
        if (hitpoints == 0)
        {
            hitpoints = 5;
        }
    }

    void Update()
    {
        //Debug.Log("Target pos: " + destinationSetter.target.transform.position); 
    }
}