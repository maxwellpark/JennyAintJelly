using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileRateOfFirePickup", menuName = "ScriptableObjects/Pickups/ProjectileRateOfFirePickup", order = 1)]
public class ProjectileRateOfFirePickup : Pickup
{
    [SerializeField] private float rateOfFireIncrease;

    public override void Claim()
    {
        ProjectileManager.CurrentRateOfFire-= rateOfFireIncrease;
    }
}
