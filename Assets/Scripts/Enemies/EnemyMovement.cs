using UnityEngine;

public class EnemyMovement : Movement
{
    private readonly float directionThreshold = 90f;

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
        throw new System.NotImplementedException();
    }

    public override void SetDirection()
    {
        float newAngle = Vector3.Angle(
            PlayerManager.PetTransform.forward, transform.position - PlayerManager.PetPosition);

        if (newAngle < directionThreshold)
        {
            SpriteAnimator.Direction = Direction.Right;
        }
        else
        {
            SpriteAnimator.Direction = Direction.Left;
        }
    }
}
