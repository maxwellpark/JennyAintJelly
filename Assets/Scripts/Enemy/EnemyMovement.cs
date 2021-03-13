using Pathfinding;
using UnityEngine;

public class EnemyMovement : Movement
{
    [SerializeField] private AIDestinationSetter destinationSetter;
    private Vector3 lastPosition;

    [SerializeField] private float moveSpeed;
    public float MoveSpeed { get => moveSpeed; }

    private void Start()
    {
        lastPosition = transform.position;
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
    }

    private Direction CalculateNextDirection(Vector3 movement)
    {
        Direction nextDirection;
        Vector3 normalised = movement.normalized;

        if (MovementUtils.IsCoordAboveThreshold(normalised, Axis.Y))
        {
            // It either needs to be facing up or left/right 
            if (MovementUtils.IsAxisDominant(normalised, Axis.Y)) 
            {
                nextDirection = Direction.Up;
            }
            else
            {
                nextDirection = MovementUtils.IsCoordAboveThreshold(normalised, Axis.X) ? Direction.Right : Direction.Left;
            }
        }
        else
        {
            // It needs to be facing down or left/right 
            if (MovementUtils.IsAxisDominant(normalised, Axis.Y))
            {
                nextDirection = Direction.Down;
            }
            else
            {
                nextDirection = MovementUtils.IsCoordAboveThreshold(normalised, Axis.X) ? Direction.Right : Direction.Left;
            }
        }
        return nextDirection;
    }
}
