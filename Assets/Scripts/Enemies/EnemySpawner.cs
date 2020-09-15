using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // simple compiletime aggro range spawner 

    // for runtime spawner: 
    // get camera position 
    // if camera moves past a point, 
    // then spawn an enemy behind the player 
    // (determine whether forward/backwards mvt) 

    public GameObject agentPrefab;
    public GameObject hazmatPrefab;
    public GameObject enemyContainer; 

    void Start()
    {
        
    }

    public static GameObject SpawnEnemy(GameObject _prefab, Vector2 _position)
    {
        GameObject newEnemy = Instantiate(_prefab);
        //newEnemy.transform.parent = enemyContainer.transform;
        newEnemy.transform.position = _position;
        return newEnemy;
    }

    void Update()
    {
        
    }
}
