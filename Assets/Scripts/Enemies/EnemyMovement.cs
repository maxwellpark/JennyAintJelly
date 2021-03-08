using UnityEngine;

public class EnemyMovement : Movement
{
    private void Update()
    {
        SetDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        // Navigation logic 

        throw new System.NotImplementedException();
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
