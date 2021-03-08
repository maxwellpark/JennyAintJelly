using UnityEngine;

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
		GameManager.OnLevelTransition += SetEnemyScaling;
	}

	// Scale up health each level 
	private static void SetEnemyScaling()
    {
		// We could pass a coefficient instead
		switch (GameManager.CurrentLevel)
        {
			case Level.Road:

				break;
			case Level.Caves:
				
				break;
			case Level.MilitaryBase:
				
				break;
			
        }
    }

	private static GameObject[] GetEnemies()
    {
		return GameObject.FindGameObjectsWithTag(EnemyConstants.EnemyTag);
    }

	public void SetStartingValues()
    {
		enemies = GetEnemies();
    }
}
