using UnityEngine;

public class PlayerMovement : Movement
{
    private void Update()
    {
        MovementVector.x = Input.GetAxisRaw("Horizontal");
        MovementVector.y = Input.GetAxisRaw("Vertical");
        SetDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public override void Move()
    {
        // Adjust for diagonal input 
        if (MovementVector.magnitude > 1f)
        {
            MovementVector /= MovementVector.magnitude;
        }

        Vector3 velocity = new Vector3(MovementVector.x, MovementVector.y, 0f);
        transform.position += velocity * PlayerManager.CurrentSpeed * Time.fixedDeltaTime;
    }

    public override void SetDirection()
    {
        if (MovementVector == Vector2.up)
        {
            SpriteAnimator.Direction = Direction.Up;
        }
        else if (MovementVector == new Vector2(-1f, 1f))
        {
            SpriteAnimator.Direction = Direction.UpLeft;
        }
        else if (MovementVector == Vector2.left)
        {
            SpriteAnimator.Direction = Direction.Left;
        }
        else if (MovementVector == new Vector2(-1f, -1f))
        {
            SpriteAnimator.Direction = Direction.DownLeft;
        }
        else if (MovementVector == Vector2.down)
        {
            SpriteAnimator.Direction = Direction.Down;
        }
        else if (MovementVector == new Vector2(1f, -1f))
        {
            SpriteAnimator.Direction = Direction.DownRight;
        }
        else if (MovementVector == Vector2.right)
        {
            SpriteAnimator.Direction = Direction.Right;
        }
        else if (MovementVector == Vector2.one)
        {
            SpriteAnimator.Direction = Direction.UpRight;
        }
    }
}
