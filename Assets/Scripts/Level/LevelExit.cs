using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.LoadNextLevel(sceneName);
            
            // Transition coroutine
        }
    }
}
