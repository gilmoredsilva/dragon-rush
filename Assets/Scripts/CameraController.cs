using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 5;
    private Vector3 velocity = Vector3.zero;
    private float CurrentPosX;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(CurrentPosX, transform.position.y, transform.position.z),
        ref velocity, speed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        CurrentPosX = _newRoom.position.x;
    }
}
