using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health, Speed, Weapon
}

[CreateAssetMenu(fileName = "Pickup", menuName = "ScriptableObjects/Pickup", order = 1)]
public class PickupData : ScriptableObject
{
    public static event Action<WeaponType> onWeaponPickup;

    public GameObject prefab;

    public PickupType pickupType;
    public WeaponType weaponType;
    public Vector2 coordinates;

    // This increases either damage or speed based on the type of pickup
    public int value; 

    public void TriggerPickup()
    {
        switch (pickupType)
        {
            case PickupType.Weapon:
                PlayerData.damage = value; 
                onWeaponPickup?.Invoke(weaponType);
                break;

            case PickupType.Speed:
                if (PlayerMovement.speed <= PlayerMovement.maxSpeed)
                {
                    PlayerMovement.speed += value;
                    // Clamp this value if it's a balancing issue later on 
                }
                break;
        }
    }
}

