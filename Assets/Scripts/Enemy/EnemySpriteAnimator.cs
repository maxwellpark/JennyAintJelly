using UnityEngine;

public class EnemySpriteAnimator : SpriteAnimator
{
    public override void Animate()
    {
        if (movement.MovementVector == Vector2.zero)
        {
            spriteRenderer.sprite = stationaryPosition;
        }
        else
        {
            UpdateFrameArray();
            //timer += Time.deltaTime;
            timer += 0.001f;
            Debug.Log("Dt = " + Time.deltaTime);
            Debug.Log("Anim frame = " + currentFrame);
            if (timer >= frameRate)
            {
                timer -= frameRate;
                spriteRenderer.sprite = frameArray[currentFrame];
                currentFrame = currentFrame < frameArray.Length - 1 ? currentFrame + 1 : 0;
            }

        }
    }
}
