using UnityEngine;

public class SpeedIncreasePickup : Pickup
{
    [SerializeField] private float speedIncrease;

    public override void Claim()
    {
        PlayerManager.CurrentSpeed += speedIncrease;
    }
}
