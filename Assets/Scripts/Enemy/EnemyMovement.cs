using Pathfinding;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] Rigidbody2D rigidBody;
    [SerializeField] AIDestinationSetter destinationSetter;

    private Vector3 lastPosition;

    private void Start()
    {
        lastPosition = transform.position;
        lastDirection = Vector3.zero;
    }

    private void Update()
    {
        MovementVector = transform.position - lastPosition;
        SetDirection();
        lastPosition = transform.position;
    }

    public override void SetDirection()
    {
        SpriteAnimator.Direction = CalculateNextDirection(MovementVector);

        Debug.Log(MovementVector);
    }

    private Direction CalculateNextDirection(Vector3 movement)
    {
        Direction nextDirection;
        Vector3 normalised = movement.normalized;

        if (normalised.y > 0.1f)
        {
            // Go up
            if (normalised.y > Mathf.Abs(normalised.x) + 0.1f) // Leeway
            {
                nextDirection = Direction.Up;
            }
            else
            {
                if (normalised.x > 0.1f)
                {
                    nextDirection = Direction.Right;

                }
                else
                {
                    nextDirection = Direction.Left;
                }
            }
        }
        else
        {
            if (Mathf.Abs(normalised.y) > Mathf.Abs(normalised.x) + 0.1f) // Leeway
            {
                nextDirection = Direction.Down;
            }
            else
            {
                if (normalised.x > 0.1f)
                {
                    nextDirection = Direction.Right;

                }
                else
                {
                    nextDirection = Direction.Left;
                }
            }
        }
        
        return nextDirection;
    }
}
