using UnityEngine;

public interface IPickup
{
    void Claim();
}

public abstract class Pickup : ScriptableObject, IPickup
{
    [SerializeField] private string pickupName;
    [SerializeField] private float spawnDelayInMilliseconds;
    private bool hasSpawned;

    public abstract void Claim();
}
