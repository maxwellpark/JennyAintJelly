using UnityEngine;

public class Crosshair : MonoBehaviour
{
    public GameObject hitCursorPrefab;
    public GameObject missCursorPrefab;

    public Texture2D cursorTexture;
    
    [SerializeField] private Sprite cursorSprite;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private Vector2 cursorPosition;

    private void Start()
    {
        transform.position = Vector3.forward;

        Cursor.visible = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cursorSprite;

        // We should set the cursor colour programmatically 
    }

    private void Update()
    {
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;

        RotateCursor();
    }

    private void RotateCursor()
    {
        //transform.RotateAround(
        //    transform.position, Vector3.forward, PetConstants.ZRotationSpeed * Time.deltaTime);

        //transform.localRotation += new Vector3(0f, 0f, PetConstants.ZRotationSpeed) * Time.deltaTime);
        float zDelta = transform.eulerAngles.z + PetConstants.CursorRotationSpeed;
        transform.eulerAngles += new Vector3(0f, 0f, zDelta); 
    }
}
