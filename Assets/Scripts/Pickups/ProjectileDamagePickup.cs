using UnityEngine;

public class ProjectileDamagePickup : Pickup
{
    [SerializeField] private float damageIncrease;

    public override void Claim()
    {
        ProjectileManager.CurrentDamage += damageIncrease;
    }
}
