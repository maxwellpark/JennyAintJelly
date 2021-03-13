using UnityEngine;

public abstract class SpriteAnimator : MonoBehaviour
{
    // The sprites to loop through when moving  
    [SerializeField] protected Sprite[] upFrames;
    [SerializeField] protected Sprite[] leftFrames;
    [SerializeField] protected Sprite[] downFrames;
    [SerializeField] protected Sprite[] rightFrames;

    // Stores the currently looping sprites 
    protected Sprite[] frameArray;
    
    // The sprites displayed when stationary  
    // Indices are: 0-3 WASD
    [SerializeField] protected Sprite[] stationaryFrames;

    // Stores the current stationary sprite
    protected Sprite stationaryPosition;

    protected SpriteRenderer spriteRenderer;

    [SerializeField] protected float frameRate;
    protected int currentFrame;
    protected float timer;
    protected bool flipped;

    [SerializeField] protected Movement movement;
    public Direction Direction;

    public virtual void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Default stationary position is facing down 
        stationaryPosition = stationaryFrames[2];
        spriteRenderer.sprite = stationaryPosition;
    }

    public virtual void Update()
    {
        Animate();
    }

    public virtual void Animate()
    {
        if (movement.MovementVector == Vector2.zero)
        {
            spriteRenderer.sprite = stationaryPosition;
        }
        else
        {
            UpdateFrameArray();
            timer += Time.deltaTime;

            // Do something every "frame",
            // according to the frameRate defined above 
            if (timer >= frameRate)
            {
                timer -= frameRate;

                // Reset currentFrame to 0 when it reaches the length of the array 
                currentFrame = (currentFrame + 1) % frameArray.Length;

                // Flip sprite if moving left 
                spriteRenderer.flipX = flipped;

                // Update the sprite being rendered
                spriteRenderer.sprite = frameArray[currentFrame];
            }
        }
    }

    // Assign frameArray to the frames corresponding to 
    // the object's current direction 
    public void UpdateFrameArray()
    {
        switch (Direction)
        {
            case Direction.Up:
                frameArray = upFrames;
                stationaryPosition = stationaryFrames[0];
                flipped = false;
                break;
            case Direction.UpLeft:
                frameArray = leftFrames;
                stationaryPosition = stationaryFrames[1];
                flipped = false;
                break;
            case Direction.Left:
                frameArray = leftFrames;
                stationaryPosition = stationaryFrames[1];
                flipped = false;
                break;
            case Direction.DownLeft:
                frameArray = leftFrames;
                stationaryPosition = stationaryFrames[1];
                flipped = false;
                break;
            case Direction.Down:
                frameArray = downFrames;
                stationaryPosition = stationaryFrames[2];
                flipped = false;
                break;
            case Direction.DownRight:
                frameArray = rightFrames;
                stationaryPosition = stationaryFrames[3];
                flipped = false;
                break;
            case Direction.Right:
                frameArray = rightFrames;
                stationaryPosition = stationaryFrames[3];
                flipped = false;
                break;
            case Direction.UpRight:
                frameArray = rightFrames;
                stationaryPosition = stationaryFrames[3];
                flipped = false;
                break;
        }
    }
}
