﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    int enemyCount = 5;

    public GameObject enemyContainer;
    public LayerMask enemyLayer;

    Vector2[] enemyPositions = new Vector2[]
    {
        new Vector2(-1.5f, -1f),
        new Vector2(0f, -0.5f),
        new Vector2(2f, 1f),
        new Vector2(-1f, 2f),
        new Vector2(-1f, 1f)
    };

    // random coords in range defined. 
    // but account for overlapping pos. 

    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            GameObject newEnemy = Instantiate(enemyPrefab);
            newEnemy.transform.parent = enemyContainer.transform;
            newEnemy.transform.position = enemyPositions[i];
            Debug.Log(newEnemy.transform.position);

        }
    }

    void Update()
    {
        if (enemyContainer.transform.childCount <= 0)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}