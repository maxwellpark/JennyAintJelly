using UnityEngine;

public class MoveSpeedPickup : Pickup
{
    [SerializeField] private float speedIncrease;

    public override void Claim()
    {
        PlayerManager.CurrentSpeed += speedIncrease;
    }
}
