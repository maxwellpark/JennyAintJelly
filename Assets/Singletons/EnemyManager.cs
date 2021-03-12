using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour, ISingleton
{
	public static EnemyManager Instance { get; private set; }

	public static GameObject[] enemies;

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
		Init();
		SceneManager.sceneLoaded += Init;
	}

	public void Init()
	{
		SetDefaults();
		SetEnemyScaling();
	}

	public void Init(Scene scene, LoadSceneMode mode)
	{
		Init();
	}

	// Scale up health each level 
	private static void SetEnemyScaling()
    {
		// We could pass a coefficient instead
		switch (GameManager.CurrentLevel)
        {
			case Level.Route1:

				break;
			case Level.Caves:
				
				break;
			case Level.CavesBoss:

				break;
			case Level.MilitaryBase:
				
				break;
        }
    }

	private static GameObject[] GetEnemies()
    {
		return GameObject.FindGameObjectsWithTag(EnemyConstants.EnemyTag);
    }

	public void SetDefaults()
    {
		enemies = GetEnemies();
    }
}
