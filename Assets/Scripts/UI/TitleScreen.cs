using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public Button enterGameBtn;
    public GameObject gameOverText;

    void Start()
    {
        enterGameBtn.onClick.AddListener(delegate { EnterGame(); });
    }

    void EnterGame()
    {
        PlayerData.gameOver = false;
        SceneManager.LoadScene("Route 1");
    }

    // separate game over class?
    void DisplayGameOverText()
    {
        if (PlayerData.gameOver)
        {
            gameOverText.SetActive(true);
        }
    }
}
