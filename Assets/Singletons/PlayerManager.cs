using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour, ISingleton
{
	public static PlayerManager Instance { get; private set; }

	// Player state 
	public static GameObject Player;
	public static Collider2D PlayerCollider;
	public static float CurrentSpeed { get; set; }

	// Pet state 
	public static GameObject Pet;
	public static Collider2D PetCollider;

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
		// Get player references 
		Player = GameObject.FindGameObjectWithTag(PlayerConstants.PlayerTag);
		PlayerCollider = Player.GetComponent<Collider2D>();

		// Get pet references
		Pet = GameObject.FindGameObjectWithTag(PetConstants.PetTag);
		PetCollider = Pet.GetComponent<Collider2D>();

		SetDefaults();
	}

	// Subscribe this to the SceneManager's sceneLoaded event 
	public void Init(Scene scene, LoadSceneMode mode)
    {
		Init();
	}

	public void SetDefaults()
    {
		CurrentSpeed = PlayerConstants.DefaultMoveSpeed;
    }
}
