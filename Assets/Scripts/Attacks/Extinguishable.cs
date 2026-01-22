using UnityEngine;

public class Extinguishable : MonoBehaviour
{
    public float damage;
    public void StartExtinguishing()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
