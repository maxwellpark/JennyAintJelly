using UnityEngine;

public class EnemySpriteAnimator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField]
    private float frameRate = 0.15f;

    // The sprites to loop through when moving  
    public Sprite[] upFrames;
    public Sprite[] leftFrames;
    public Sprite[] downFrames;
    public Sprite[] rightFrames;

    // Stores the currently looping sprites 
    private Sprite[] frameArray;

    // The sprites displayed when stationary  
    // Indices are: 0-3 WASD
    public Sprite[] stationaryFrames;

    // Stores the current stationary sprite
    private Sprite stationaryPosition;

    private int currentFrame;
    private float timer;

    public Direction direction;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.flipX = false;
        spriteRenderer.flipY = false; 

        // Default stationary position is facing down 
        stationaryPosition = stationaryFrames[2];
        spriteRenderer.sprite = stationaryPosition;

        // Set frame rate proportionally to movement speed 
        // Enable this when not Serialized
        // And set movementSpeed to static member*
        //frameRate = PlayerMovement.movementSpeed / 1000; 

    }

    void FixedUpdate()
    {
        //if (PlayerMovement.movement == Vector2.zero)
        //{
        //    spriteRenderer.sprite = stationaryPosition;
        //}

        UpdateFrameArray();

        timer += Time.fixedDeltaTime;

        // Do something every "frame",
        // according to the frameRate defined above 
        if (timer >= frameRate)
        {
            timer -= frameRate;

            // Reset currentFrame to 0 when it reaches the length of the array 
            currentFrame = (currentFrame + 1) % frameArray.Length;

            // Update the sprite being rendered
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }

    // Assign frameArray to the frames corresponding to 
    // the player's current direction 
    private void UpdateFrameArray()
    {
        switch (direction)
        {
            case Direction.Up:
                frameArray = upFrames;
                stationaryPosition = stationaryFrames[0];
                break;
            case Direction.UpLeft:
                frameArray = leftFrames;
                stationaryPosition = stationaryFrames[1];
                break;
            case Direction.Left:
                frameArray = leftFrames;
                stationaryPosition = stationaryFrames[1];
                break;
            case Direction.DownLeft:
                frameArray = leftFrames;
                stationaryPosition = stationaryFrames[1];
                break;
            case Direction.Down:
                frameArray = downFrames;
                stationaryPosition = stationaryFrames[2];
                break;
            case Direction.DownRight:
                frameArray = rightFrames;
                stationaryPosition = stationaryFrames[3];
                break;
            case Direction.Right:
                frameArray = rightFrames;
                stationaryPosition = stationaryFrames[3];
                break;
            case Direction.UpRight:
                frameArray = rightFrames;
                stationaryPosition = stationaryFrames[3];
                break;
        }
    }
}