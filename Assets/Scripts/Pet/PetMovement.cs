using UnityEngine;

public class PetMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    private Vector2 petDistance = new Vector2(1f, 0f);


    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        // Reverse direction of vector 
        Vector3 headDirection = mousePosition - transform.position;

        // Angle between x axis and directional vector (x,y)
        float zAngle = Mathf.Atan2(headDirection.y, headDirection.x) * Mathf.Rad2Deg + -90f; // +/- 90f 

        transform.rotation = Quaternion.Euler(0f, 0f, zAngle);

        Vector2 playerPosition = PlayerManager.playerObject.transform.position;
        transform.position = playerPosition - petDistance;
    }
}
