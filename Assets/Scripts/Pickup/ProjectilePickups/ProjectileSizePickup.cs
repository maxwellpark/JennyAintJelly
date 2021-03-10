using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileSizePickup", menuName = "ScriptableObjects/Pickups/ProjectileSizePickup", order = 1)]
public class ProjectileSizePickup : Pickup
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private AudioClip projectileSoundEffect;

    public override void Claim()
    {
        ProjectileManager.SetCurrentProjectile(projectilePrefab, projectileSoundEffect);
    }
}
