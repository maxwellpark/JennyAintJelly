using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static int damage = 1;
    public static int lives = 3;
    public static int killCount = 0; 
    public static int slowAmount = 0;
    // movement data decoupled 

    public static bool playerDead;
    public static bool gameOver;

    private void Start()
    {
        // temporary default workaround: 
        SetDefaults();

        EnemyInteraction.onEnemyDeath += () => killCount++; 
    }

    private void SetDefaults()
    {
        damage = 1;
        slowAmount = 0;
        PlayerMovement.speed = 10f;
    }
}
