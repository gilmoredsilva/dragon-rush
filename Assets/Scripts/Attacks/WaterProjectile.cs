using UnityEngine;

public class WaterProjectile : MonoBehaviour
{
    public float waterspeed;
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
        float movementSpeed = waterspeed * Time.deltaTime * direction;
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
        anim.SetTrigger("Splash");

        if (collision.gameObject.CompareTag("Extinguishable"))
        {
            collision.gameObject.GetComponent<Extinguishable>()?.StartExtinguishing();
        }

        if (collision.tag == "Enemy" || collision.tag == "RangedEnemy")
        {
            collision.GetComponent<Health>().TakeDamage(0.5f);
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            collision.GetComponent<Health>().TakeDamage(0.25f);
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
