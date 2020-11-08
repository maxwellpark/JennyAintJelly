using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    // We can access the player and pet objects globally via these
    public static GameObject playerObject;
    public static GameObject petObject;

    public static int damage = 1;
    public static int lives = 3;

    public static bool playerDead;
    public static bool gameOver;

    private void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        petObject = GameObject.FindGameObjectWithTag("Pet");
        SetDefaults();
    }

    private void SetDefaults()
    {
        damage = 1;
        PlayerMovement.speed = 10f;
    }
}
