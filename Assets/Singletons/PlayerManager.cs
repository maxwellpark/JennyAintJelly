using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager Instance { get; private set; }

	// Player state 
	private static GameObject playerObject;
	public static Collider2D PlayerCollider;
	public static Vector3 PlayerPosition => playerObject.transform.position;
	public static Vector3 PlayerRotation => playerObject.transform.eulerAngles;
	public static float CurrentSpeed { get; set; }
	public static bool IsPlayerDead { get; set; }

	// Pet state 
	private static GameObject petObject;
	public static Collider2D PetCollider;
	public static Vector3 PetPosition => petObject.transform.position;
	public static Vector3 PetRotation => petObject.transform.eulerAngles;

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

        petObject = GameObject.FindGameObjectWithTag(PlayerConstants.PetTag);
		PetCollider = petObject.GetComponent<Collider2D>();
	}
}
