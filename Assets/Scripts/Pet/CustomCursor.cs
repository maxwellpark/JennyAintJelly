using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public GameObject hitCursorPrefab;
    public GameObject missCursorPrefab;

    public Sprite cursorSprite;
    public Texture2D cursorTexture;
    private SpriteRenderer spriteRenderer;

    Vector2 cursorPosition;

    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        transform.position = Vector3.forward;
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cursorSprite;

        // We should set the cursor colour programmatically 
    }

    private void Update()
    {
        transform.position = cursorPosition;

        //Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //RotateCursor();
    }

    private void RotateCursor()
    {
        transform.RotateAround(
            transform.position, Vector3.forward, PetConstants.zRotationSpeed * Time.deltaTime);
    }
}
