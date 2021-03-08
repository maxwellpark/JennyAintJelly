using UnityEngine;

[CreateAssetMenu(fileName = "Pickups/ProjectileSizePickup", menuName = "ScriptableObjects/ProjectileSizePickup", order = 1)]
public class ProjectileSizePickup : Pickup
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AudioClip projectileSoundEffect;

    public override void Claim()
    {
        ProjectileManager.SetCurrentProjectile(projectilePrefab, projectileSoundEffect);
    }
}
