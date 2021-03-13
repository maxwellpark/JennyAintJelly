using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Sprite cursorSprite;
    [SerializeField] private Sprite hitCursorSprite;
    [SerializeField] private Sprite missCursorSprite;

    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 cursorPosition;

    private void Start()
    {
        transform.position = Vector3.forward;

        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cursorSprite;
    }

    private void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
        RotateCursor();
    }

    private void RotateCursor()
    {
        float zDelta = PetConstants.CrosshairRotationSpeed * Time.deltaTime;
        transform.localEulerAngles += new Vector3(0f, 0f, zDelta);
    }

    public void SetCursorSprite(bool isOnTarget)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = isOnTarget ? hitCursorSprite : cursorSprite;
        }
    }
}
