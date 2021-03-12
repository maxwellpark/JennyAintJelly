using UnityEngine;

public enum Direction
{
    Up, UpLeft, Left, DownLeft, Down, DownRight, Right, UpRight
}

public abstract class Movement : MonoBehaviour
{
    public Vector2 MovementVector;
    
    [SerializeField] private SpriteAnimator spriteAnimator;
    public SpriteAnimator SpriteAnimator { get => spriteAnimator; }
    
    public virtual void Move() { }
    //public abstract void SetDirection();

    public virtual void SetDirection()
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
