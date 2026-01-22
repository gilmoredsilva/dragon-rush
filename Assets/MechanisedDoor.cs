using UnityEngine;

public class MechanisedDoor : MonoBehaviour
{
    public Vector3 targetPosition;
    public float moveSpeed = 1f;
    private bool shouldMove = false;

    public void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                shouldMove = false;
            }
        }
    }
    public void StartUnlock()
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);
        shouldMove = true;
    }
}
