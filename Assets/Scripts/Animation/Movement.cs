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
    
    public abstract void Move();
    public abstract void SetDirection();
}
