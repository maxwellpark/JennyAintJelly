using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CustomCursor : MonoBehaviour
{
    public GameObject hitCursorPrefab;
    public GameObject missCursorPrefab;

    public Sprite cursorSprite;
    public Texture2D cursorTexture;

    private float zRotation;

    private SpriteRenderer sr;

    //public CursorMode cursorMode = CursorMode.Auto;
    //public Vector2 hotSpot = Vector2.zero;


    float zRotationSpeed = 5f;

    void Start()
    {
        transform.position = Vector3.forward;

        Cursor.visible = false;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = cursorSprite;

        // We should set the cursor colour programmatically 
    }

    void Update()
    {
        Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
        //RotateCursor();
    }

    void RotateCursor()
    {
        transform.RotateAround(transform.position, Vector3.forward, zRotationSpeed * Time.deltaTime);
    }
}