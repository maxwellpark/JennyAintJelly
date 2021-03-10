using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private Level nextLevel;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PlayerConstants.PlayerTag))
        {
            GameManager.LoadNextLevel(nextLevel);
            
            // Transition coroutine
        }
    }
}
