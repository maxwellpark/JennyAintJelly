using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
	Play, Pause, Dead
}

public enum Level
{
	Road, Caves, MilitaryBase
}

public class GameManager : MonoBehaviour, ISingleton
{
	public static GameManager Instance { get; private set; }

	public static Level CurrentLevel { get; set; }
	public static event Action OnLevelTransition;

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
		Screen.fullScreen = true;
	}

	public static void ReloadLevel()
    {
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
		OnLevelTransition?.Invoke();
	}

	public static void LoadNextLevel(Level nextLevel)
    {
		CurrentLevel = nextLevel;
		string nextSceneName = GetSceneName();
		SceneManager.LoadScene(nextSceneName);
		OnLevelTransition?.Invoke();
    }

	public static string GetSceneName()
    {
		return Enum.GetName(typeof(Level), CurrentLevel);
	}

	public void SetStartingValues()
    {
		Debug.Log("Scene loaded: " + GetSceneName());
    }
}
