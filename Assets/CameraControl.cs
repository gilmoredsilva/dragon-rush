using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float speed = 1;
    private Vector3 velocity = Vector3.zero;
    public GameObject player;

    private void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
