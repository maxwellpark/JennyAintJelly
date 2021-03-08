using UnityEngine;

public class PetSpriteAnimator : MonoBehaviour
{
    [SerializeField] private Sprite[] frameArray;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private int currentFrame;
    private float timer;

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if (timer >= PetConstants.AnimationFrameRate)
        {
            timer -= PetConstants.AnimationFrameRate;

            // Reset currentFrame to 0 when it reaches the length of the array 
            currentFrame = (currentFrame + 1) % frameArray.Length;

            // Update the sprite being rendered 
            spriteRenderer.sprite = frameArray[currentFrame];
        }
    }
}
