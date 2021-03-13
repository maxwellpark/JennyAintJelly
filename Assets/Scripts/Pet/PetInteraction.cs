﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PetInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "BossProjectile")
        {
            Destroy(gameObject);
            PlayerData.lives--;

            //PauseMenu.playerDead = true;
            //PauseMenu.TogglePauseMenu(); 

            // reload the scene 
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);

            //Application.Quit(); 
        }
    }
}