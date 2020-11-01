using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Health, Speed, Weapon
}

// break these out later 
[CreateAssetMenu(fileName = "Pickup", menuName = "ScriptableObjects/Pickup", order = 1)]
public class PickupData : ScriptableObject
{
    public static event Action<WeaponType> onWeaponPickup;

    public GameObject prefab;
    public Vector2 coordinates;
    public float duration;
    public int health;
    public int damage;
    public int speedIncrease;
    public PickupType type;
    public WeaponType weaponType;

    // this ought to be in the corresponding Interaction class
    public void TriggerPickup()
    {
        //Debug.Log("Pickup triggered!"); 

        if (type == PickupType.Health)
        {
            //PlayerData.healthPoints += health; 
        }
        else if (type == PickupType.Weapon)
        {
            PlayerData.damage = damage;
            //ProjectileManager.weaponType = weaponType;
            ProjectileManager.weaponActive = true;
            ProjectileManager.weaponDuration = duration;

            onWeaponPickup?.Invoke(weaponType);
        }
        else if (type == PickupType.Speed)
        {
            PlayerMovement.speed += speedIncrease;

            // speed cap 
            if (PlayerMovement.speed >= 10)
            {
                //PlayerMovement.speed = 10; 
            }
        }


    }
}
