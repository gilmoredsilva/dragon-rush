using UnityEngine;

public class CameraControlBoss : MonoBehaviour
{
    public Transform target; // The player to follow

    public float deadZoneWidth = 1f; // Horizontal dead zone width (world units)
    public float cameraFollowSpeed = 5f; // Speed of camera movement

    private float initialY; // Fixed vertical position

    private void Start()
    {
        // Store the initial vertical position of the camera
        initialY = transform.position.y;
    }

    private void LateUpdate()
    {
        if (target == null) return;

        Vector3 cameraPos = transform.position;
        Vector3 targetPos = target.position;

        // Calculate horizontal difference
        float deltaX = targetPos.x - cameraPos.x;

        Vector3 newCameraPos = cameraPos;

        // Move camera if target is outside the horizontal dead zone
        if (Mathf.Abs(deltaX) > deadZoneWidth)
        {
            newCameraPos.x = targetPos.x - Mathf.Sign(deltaX) * deadZoneWidth;
        }

        // Keep the vertical position fixed
        newCameraPos.y = initialY;

        // Smoothly move camera towards new position
        transform.position = Vector3.Lerp(cameraPos, newCameraPos, cameraFollowSpeed * Time.deltaTime);
    }
}
