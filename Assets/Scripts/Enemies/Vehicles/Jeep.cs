using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeep : MonoBehaviour
{
    public GameObject agentPrefab;
    public Direction direction = Direction.right;

    private float speed = 4f; 
    private float distance = 64f; // change to coordinates later
    private bool destinationReached;

    private float yDelta = 12f;
    private float xDelta = 4f; 

    private int capacity = 4; 

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        while (!destinationReached)
        {
            switch (direction)
            {
                case Direction.right:
                    transform.position += new Vector3(transform.position.x + speed * Time.fixedDeltaTime, transform.position.y);
                    break;
                case Direction.left:
                    transform.position += new Vector3(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
                    break;
                case Direction.up:
                    transform.position += new Vector3(transform.position.x, transform.position.y + speed * Time.fixedDeltaTime);
                    break;
                case Direction.down:
                    transform.position += new Vector3(transform.position.x, transform.position.y - speed * Time.fixedDeltaTime);
                    break;
            }
            
            // improve this check...
            if (transform.position.x % 1 == 0 || transform.position.y % 1 == 0)
            {
                distance--; 
            }
            if (distance <= 0)
            {
                destinationReached = true; 
                
            }
        }
    }

    private void UnloadPassengers()
    {
        Vector2 enemyPosition = new Vector2(transform.position.x, transform.position.y);
        for (int i = 0; i < capacity; i++)
        {
            if (i < 2)
            {
                // put above vehicle
                GameObject enemy = Instantiate(agentPrefab);
            }
            else
            {
                // put below vehicle
            }
            //GameObject enemy = EnemySpawner.SpawnEnemy(agentPrefab);
            //enemy.transform.position 

        }
    }
}
