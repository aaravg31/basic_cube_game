using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // The target the camera should follow (usually the Player object)
    [SerializeField] private Transform cameraTarget;
    
    // Offset from the player position (so the camera isn't directly on top of them)
    [SerializeField] private Vector3 offset;
    
    // How quickly the camera smooths its movement
    [SerializeField] private float smoothTime = 0.25f;
    
    // Internal velocity reference used by SmoothDamp
    private Vector3 velocity = Vector3.zero;
    
    private void Start()
    {
        // At the start of the game, position the camera relative to the target + offset
        transform.position = cameraTarget.position + offset;
        
        // Make the camera look at the target (player)
        transform.LookAt(cameraTarget);
    }

    private void FixedUpdate()
    {
        // Calculate the desired position (player position + offset)
        Vector3 targetPosition = cameraTarget.position + offset;
        
        // Smoothly move the camera from current position → target position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        // Always make the camera look directly at the player
        transform.LookAt(cameraTarget);
    }
}
