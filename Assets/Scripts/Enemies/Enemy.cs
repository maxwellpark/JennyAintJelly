using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    
    [SerializeField] private float moveSpeed;

    public abstract void CatchPet();

}