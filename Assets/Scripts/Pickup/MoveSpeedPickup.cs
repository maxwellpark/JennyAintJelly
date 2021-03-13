using UnityEngine;

[CreateAssetMenu(fileName = "MoveSpeedPickup", menuName = "ScriptableObjects/Pickups/MoveSpeedPickup", order = 1)]
public class MoveSpeedPickup : Pickup
{
    [SerializeField] private float speedIncrease;

    public override void Claim()
    {
        PlayerManager.CurrentSpeed += speedIncrease;
    }
}
