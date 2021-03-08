using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileVelocityPickup", menuName = "ScriptableObjects/Pickups/ProjectileVelocityPickup", order = 1)]
public class ProjectileVelocityPickup : Pickup
{
    [SerializeField] private float velocityIncrease;

    public override void Claim()
    {
        ProjectileManager.CurrentRateOfFire += velocityIncrease;
    }
}
