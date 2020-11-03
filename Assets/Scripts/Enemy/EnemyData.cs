using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float movementSpeed;
    public float hitpoints;
    public int damage;
    public bool firstWave = true;

    void Start()
    {
    }

    void Update()
    {
        //Debug.Log("Target pos: " + destinationSetter.target.transform.position); 
    }
}