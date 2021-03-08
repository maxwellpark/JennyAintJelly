using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
	Play, Pause, Dead
}

public class GameManager : MonoBehaviour, ISingleton
{
	public static GameManager Instance { get; private set; }

	public static Dictionary<string, int> Levels;
	public static string CurrentLevelName { get; set; }
	public static int CurrentLevelNumber => Levels[CurrentLevelName];
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

		Levels = new Dictionary<string, int>()
		{
			{ "The Road", 1 },
			{ "The Caves", 2 },
			{ "Military Base", 3 }
		};
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
		CurrentLevelName = sceneName;
		SceneManager.LoadScene(CurrentLevelName);
		OnLevelTransition?.Invoke();
    }

	public void SetDefaults()
    {

    }
}
