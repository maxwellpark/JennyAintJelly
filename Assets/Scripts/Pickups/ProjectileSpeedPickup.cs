using UnityEngine;

public class ProjectileSpeedPickup : Pickup
{
    [SerializeField] private float speedIncrease;

    public override void Claim()
    {
        ProjectileManager.CurrentRateOfFire += speedIncrease;
    }
}
