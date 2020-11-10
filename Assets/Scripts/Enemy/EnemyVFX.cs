using UnityEngine;
using Pathfinding;

// this could be amalgamated with 
// the EnemySpriteAnimator, 
// and the aiPath response put elsewhere 
// 
public class EnemyVFX : MonoBehaviour
{
    Transform petTransform;

    AIPath aiPath;
    AIDestinationSetter destinationSetter;
    EnemySpriteAnimator enemySpriteAnimator;

    // Point above which the sprite faces left 
    // or right, rather than up or down 
    [SerializeField] float verticalThreshold;
    float threshold = 90f;

    float newAngle; 

    void Start()
    {
        aiPath = GetComponent<AIPath>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        enemySpriteAnimator = GetComponent<EnemySpriteAnimator>();

        petTransform = GameObject.FindGameObjectWithTag("Pet").transform;
        destinationSetter.target = petTransform;
    }

    void Update()
    {
        SetEnemySpriteDirection();
    }

    void SetEnemySpriteDirection()
    {
        float threshold = 90f;
        newAngle = Vector3.Angle(petTransform.forward, transform.position - petTransform.position);

        if (newAngle < threshold)
        {
            enemySpriteAnimator.direction = Direction.right;
        }
        else
        {
            enemySpriteAnimator.direction = Direction.left; 
        }
    }

    void OnDrawGizmos()
    {
        //Gizmos.DrawLine(transform.position, petTransform.position);
        //Gizmos.DrawLine(transform.position, transform.forward * Mathf.Infinity);

        float totalFOV = 70.0f;
        float rayRange = 10.0f;
        float halfFOV = totalFOV / 2.0f;
        Quaternion leftRayRotation = Quaternion.AngleAxis(-halfFOV, Vector3.up);
        Quaternion rightRayRotation = Quaternion.AngleAxis(halfFOV, Vector3.up);
        Vector3 leftRayDirection = leftRayRotation * transform.forward;
        Vector3 rightRayDirection = rightRayRotation * transform.forward;
        Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
    }
}