using UnityEngine;

public class VerticalScript : MonoBehaviour
{
    public Vector2 platformVelocity;
    private float upLimit;
    private float downLimit;
    public float movementDistance;
    public float speed;
    private bool movingUp;

    private void Awake()
    {
        upLimit = transform.position.y - movementDistance;
        downLimit = transform.position.y + movementDistance;
    }

    private void Update()
    {
        platformVelocity = movingUp ? Vector2.up * speed : Vector2.down * speed;
        if (movingUp)
        {
            if (transform.position.y > upLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - speed * Time.deltaTime, transform.position.z);
            }
            else
            {
                movingUp = false;
            }
        }
        else
        {
            if (transform.position.y < downLimit)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);

            }
            else
            {
                movingUp = true;
            }
        }
    }
}

