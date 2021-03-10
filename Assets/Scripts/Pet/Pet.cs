using UnityEngine;

public class Pet : MonoBehaviour
{
    private Vector3 mousePosition;

    [SerializeField] private Sprite[] frameArray;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private int currentFrame;
    private float timer;

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        RotatePet();
        CycleFrames();
    }

    private void RotatePet()
    {
        // Reverse direction of vector 
        Vector3 headDirection = mousePosition - transform.position;

        // Angle between x axis and directional vector (x,y)
        float zAngle = Mathf.Atan2(headDirection.y, headDirection.x) * Mathf.Rad2Deg + -90f; // +/- 90f 

        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);
        transform.position = PlayerManager.PlayerPosition - PetConstants.DistanceFromPlayer;
    }

    private void CycleFrames()
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
