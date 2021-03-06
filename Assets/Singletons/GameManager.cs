﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
	Play, Pause, GameOver
}

public enum Level
{
	Route1, Caves, CavesBoss, MilitaryBase
}

public class GameManager : MonoBehaviour, ISingleton
{
	public static GameManager Instance { get; private set; }

	public static GameState CurrentState { get; set; }
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
		SceneManager.sceneLoaded += Init;
	}

	public void Init() 
	{
		SetDefaults();
	}

	// Subscribe this to the SceneManager's sceneLoaded event 
	public void Init(Scene scene, LoadSceneMode mode) 
	{
		Init();
	}

	public static void ReloadLevel()
    {
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
		CurrentState = GameState.Play;
	}

	public static void LoadNextLevel(Level nextLevel)
    {
		CurrentLevel = nextLevel;
		string nextSceneName = GetSceneName();
		SceneManager.LoadScene(nextSceneName);
    }

	public static string GetSceneName()
    {
		return Enum.GetName(typeof(Level), CurrentLevel);
	}

	public void SetDefaults()
    {
		Debug.Log("Scene loaded: " + GetSceneName());
    }
}
