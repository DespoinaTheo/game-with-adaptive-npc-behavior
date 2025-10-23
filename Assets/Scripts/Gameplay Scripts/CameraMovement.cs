using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;   
    public Vector3 offset;     // Fixed distance from the player

    private Quaternion fixedRotation; // Fixed rotation

    void Start()
    {
        // we save the initial camera's rotation
        fixedRotation = transform.rotation;
    }

    void LateUpdate()
    {
        if (player != null)
        {
            // Player's running position
            Vector3 targetPosition = player.position + offset;

            // Nothing changes on axis y
            targetPosition.y = transform.position.y;

            // Updates camera's position
            transform.position = targetPosition;

            // Applies fixed rotation
            transform.rotation = fixedRotation;
        }
    }
}
