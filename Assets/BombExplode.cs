using UnityEngine;

public class BombExplode : MonoBehaviour
{
    private Animator anim;
    public float offset = 1;
    public GameObject newBomb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Player"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z);
            anim.SetTrigger("Explode");
            Destroy(gameObject, 0.25f);
            if(collision.gameObject.GetComponent<Health>() != null)
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(2f);
            }
        }
    }
}
