using UnityEngine;

public class ElectroSparkProjectile : MonoBehaviour
{
    public float electrospeed;
    private bool hit;
    private BoxCollider2D boxcollider;
    private Animator anim;
    private float direction;
    private float lifetime;

    private void Awake()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (hit) return;
        float movementSpeed = electrospeed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxcollider.enabled = false;
        anim.SetTrigger("Discharge");

        if (collision.gameObject.CompareTag("Fryable"))
        {
            collision.gameObject.GetComponent<Fryable>()?.StartFrying();
        }
        if (collision.gameObject.CompareTag("MechanisedDoor"))
        {
            collision.gameObject.GetComponent<MechanisedDoor>()?.StartUnlock();
        }
        if (collision.tag == "Enemy" || collision.tag == "RangedEnemy")
        {
            collision.GetComponent<Health>().TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.GetComponent<Health>().TakeDamage(0.5f);
        }
    }

    public void setDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxcollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}

