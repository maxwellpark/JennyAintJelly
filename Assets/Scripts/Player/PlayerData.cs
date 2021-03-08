using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerData", order = 1)]
public class PlayerData : ScriptableObject
{
    public static bool playerDead;
    public static bool gameOver;

    private void Start()
    {

        SetDefaults();
    }
}
