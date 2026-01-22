using UnityEngine;

public class HomingProjectile : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;               // Horizontal speed
    public float verticalHomingSpeed = 5f; // Vertical aiming speed

    private bool hasHomed = false;         // To track if initial homing is done
    private float initialVerticalSpeed = 0f;
    private Animator anim;
    private bool hasCollided = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        if (target != null)
        {
            // Calculate vertical direction to target Y
            float deltaY = target.position.y - transform.position.y;

            // Calculate vertical speed needed to reach target Y
            initialVerticalSpeed = Mathf.Clamp(deltaY, -verticalHomingSpeed, verticalHomingSpeed);
            hasHomed = true;
        }
    }

    private void Update()
    {
        // Keep rotation fixed to avoid weird rotations
        transform.rotation = Quaternion.identity;

        if (hasCollided) return;

        // Move horizontally to the left
        Vector3 newPos = transform.position;
        newPos.x -= speed * Time.deltaTime;

        // Apply initial vertical movement only if homing done
        if (hasHomed)
        {
            newPos.y += initialVerticalSpeed * Time.deltaTime;
        }

        transform.position = newPos;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        hasCollided = true;
        anim.SetTrigger("Explode");
        Destroy(gameObject, 0.25f);
        if(other.gameObject.GetComponent<Health>() != null && other.tag != "Boss")
        {
            other.gameObject.GetComponent<Health>().TakeDamage(1f);
        }
    }
}
