using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileDamagePickup", menuName = "ScriptableObjects/Pickups/ProjectileDamagePickup", order = 1)]
public class ProjectileDamagePickup : Pickup
{
    [SerializeField] private float damageIncrease;

    public override void Claim()
    {
        ProjectileManager.CurrentDamage += damageIncrease;
    }
}
