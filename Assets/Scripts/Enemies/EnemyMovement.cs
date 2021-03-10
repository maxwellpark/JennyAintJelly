using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : Movement
{
    //private void Update()
    //{
    //    SetDirection();
    //}

    [SerializeField] NavMeshAgent agent;

    private void Start()
    {
        //agent.SetDestination(PlayerManager.PetPosition);
    }

    private void FixedUpdate()
    {
        Move();
        agent.SetDestination(PlayerManager.PetPosition);
        Debug.Log($"Destination: {agent.destination.x}, {agent.destination.y}");
    }

    public override void Move()
    {
        // Navigation logic

        Vector3 newPosition = agent.transform.position;
        Quaternion newRotation = agent.transform.rotation;

        transform.position = newPosition;
        //transform.rotation = newRotation;
        SpriteAnimator.transform.position = newPosition;
        //SpriteAnimator.transform.rotation = newRotation;

        //agent.transform.position = transform.position;
        //agent.transform.position = transform.position;
    }

    public override void SetDirection()
    {
        float newAngle = Vector3.Angle(
            PlayerManager.PetTransform.forward, transform.position - PlayerManager.PetPosition);

        if (newAngle < EnemyConstants.DirectionThreshold)
        {
            SpriteAnimator.Direction = Direction.Right;
        }
        else
        {
            SpriteAnimator.Direction = Direction.Left;
        }
    }
}
