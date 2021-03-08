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
            enemySpriteAnimator.direction = Direction.Right;
        }
        else
        {
            enemySpriteAnimator.direction = Direction.Left; 
        }
    }
}