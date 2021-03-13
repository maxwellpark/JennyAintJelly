using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSizePickup", menuName = "ScriptableObjects/Pickups/ProjectileSizePickup", order = 1)]
public class ProjectileSizePickup : Pickup
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AudioClip projectileSoundEffect;

    // Larger projectiles can have larger masses
    [SerializeField] private float projectileMass;

    public override void Claim()
    {
        ProjectileManager.SetCurrentProjectile(projectilePrefab, projectileSoundEffect);
    }
}
