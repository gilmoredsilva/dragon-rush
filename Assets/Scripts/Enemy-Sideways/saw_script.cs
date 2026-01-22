using UnityEngine;

public class saw_script : MonoBehaviour
{
    public float damage = 1f;
    public float movementDistance;
    public float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;
    public bool disabled = false;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
    }

    private void Update()
    {
        if (!disabled)
        {
            if (movingLeft)
            {
                if (transform.position.x > leftEdge)
                {
                    transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                }
                else
                {
                    movingLeft = false;
                }
            }
            else
            {
                if (transform.position.x < rightEdge)
                {
                    transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

                }
                else
                {
                    movingLeft = true;
                }
            }
        }
    }

    public void DisableSaw()
    {
        disabled = true;
        damage = 0f;
        GetComponent<Animator>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
