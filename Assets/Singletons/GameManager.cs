using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set; }
	private static string currentSceneName;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
			return;
		}
	}

    private void Start()
    {
		Screen.fullScreen = true;
	}

	public static void ReloadLevel()
    {
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}

	public static void LoadNextLevel(string sceneName)
    {
		SceneManager.LoadScene(sceneName);
    }
}
