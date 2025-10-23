using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 50f;   // plsyer's speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()   
    {
        CalculateMovement(); // It calls player's movement function
    }

    void CalculateMovement()
    {
        float moveX = 0f;
        float moveZ = 0f;

        // Input check
        if (Input.GetKey(KeyCode.RightArrow)) moveX = 1f;        
        if (Input.GetKey(KeyCode.LeftArrow)) moveX = -1f;
        if (Input.GetKey(KeyCode.UpArrow)) moveZ = 1f;
        if (Input.GetKey(KeyCode.DownArrow)) moveZ = -1f;

        Vector3 movement = new Vector3(moveX, 0f, moveZ).normalized * speed; // Movement direction

        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);  // Apply velocity in every axis

    }
}
