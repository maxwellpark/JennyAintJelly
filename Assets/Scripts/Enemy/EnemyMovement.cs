using Pathfinding;
using UnityEngine;

public class EnemyMovement : Movement
{
    Vector3 lastPosition;
    Vector3 lastDirection;

    [SerializeField] AIDestinationSetter destinationSetter;

    private void Start()
    {
        lastPosition = transform.position;
        lastDirection = Vector3.zero;
    }

    private void Update()
    {
        SetDirection();
    }

    public override void SetDirection()
    {
        Vector3 velocity = transform.position - lastPosition;
        Vector3 direction = transform.TransformDirection(velocity);

        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x >= 0)
            {
                // Right
                SpriteAnimator.Direction = Direction.Right;
            }
            else
            {
                // Left
                SpriteAnimator.Direction = Direction.Left;
            }
        }
        else
        {
            if (direction.y >= 0)
            {
                // Up
                SpriteAnimator.Direction = Direction.Up;
            }
            else
            {
                // Down
                SpriteAnimator.Direction = Direction.Down;
            }
        }

        Debug.Log(direction);
        lastDirection = direction;
    }
}
