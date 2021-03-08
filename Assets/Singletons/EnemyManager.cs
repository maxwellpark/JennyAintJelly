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
		switch (GameManager.CurrentLevelNumber)
        {
			case 1:
				break;
			case 2:
				break;
			case 3:
				break;
			
        }
    }

	private static void GetEnemies()
    {
		enemies = GameObject.FindGameObjectsWithTag(EnemyConstants.EnemyTag);
    }

	public void SetDefaults()
    {

    }
}
