using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    public float damage = 1f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Spike triggered by: " + other.name);
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(damage);
        }
    }
}
