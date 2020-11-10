using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float hitpoints;
    public float movementSpeed;
    public float aggroRange;

    private float defaultHitpoints = 5;
    private float defaultMovementSpeed = 10;
    private float defaultAggroRange = 8f;

    private void Awake()
    {
        SetDefaults();
    }

    private void SetDefaults()
    {
        if (hitpoints <= 0)
        {
            hitpoints = defaultHitpoints;
        }
        if (movementSpeed <= 0)
        {
            movementSpeed = defaultMovementSpeed;
        }
        if (aggroRange <= 0)
        {
            aggroRange = defaultAggroRange;
        }
    }
}