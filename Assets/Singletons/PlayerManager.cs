using UnityEngine;

public class PlayerManager : MonoBehaviour, ISingleton
{
	public static PlayerManager Instance { get; private set; }

	// Player state 
	private static GameObject playerObject;
	public static Collider2D PlayerCollider;
	public static Transform PlayerTransform => playerObject.transform;
	public static Vector3 PlayerPosition => PlayerTransform.position;
	public static Vector3 PlayerRotation => PlayerTransform.eulerAngles;
	public static float CurrentSpeed { get; set; }
	public static bool IsPlayerDead { get; set; }

	// Pet state 
	private static GameObject petObject;
	public static Collider2D PetCollider;
	public static Transform PetTransform => petObject.transform;
	public static Vector3 PetPosition => PetTransform.position;
	public static Vector3 PetRotation => PetTransform.eulerAngles;

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
		playerObject = GameObject.FindGameObjectWithTag(PlayerConstants.PlayerTag);
		PlayerCollider = playerObject.GetComponent<Collider2D>();

        petObject = GameObject.FindGameObjectWithTag(PetConstants.PetTag);
		PetCollider = petObject.GetComponent<Collider2D>();

		GameManager.OnLevelTransition += SetStartingValues;
	}

	public void SetStartingValues()
    {
		CurrentSpeed = PlayerConstants.DefaultMoveSpeed;
		IsPlayerDead = false;
    }
}
