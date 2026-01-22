using UnityEngine;
using System.Collections.Generic;

public class DendroProjectile : MonoBehaviour
{
    public float dendrospeed;
    private bool hit;
    private BoxCollider2D boxcollider;
    private float direction;
    private float lifetime;
    private Transform player;
    private LineRenderer lineRenderer;
    public Transform firePoint;
    private HashSet<Collider2D> hitEnemies = new HashSet<Collider2D>();
    private Movement playerMovement;
    private void Awake()
    {
        boxcollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        lineRenderer = GetComponent<LineRenderer>();
        playerMovement = player.GetComponent<Movement>();
    }

    private void Update()
    {
        if (hit)
        {
            Return();
        }
        else
        {
            float movementSpeed = dendrospeed * Time.deltaTime * direction;
            transform.Translate(movementSpeed, 0, 0);
        }

        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.startWidth = 0.05f;
            lineRenderer.endWidth = 0.05f;
            Vector3 offset = new Vector3(0f, -0.5f, 0f);
            Vector3 start = player.position + offset;
            lineRenderer.SetPosition(0, start);         // Start of the line (player)
            lineRenderer.SetPosition(1, transform.position);      // End of the line (projectile)
        }

        lifetime += Time.deltaTime;
        if (lifetime > 10)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Enemy") || collision.CompareTag("RangedEnemy"))
    {
        if (!hitEnemies.Contains(collision))
        {
            collision.GetComponent<Health>().TakeDamage(0.1f);
            EnemyPatrol enemyPatrol = collision.GetComponentInParent<EnemyPatrol>();
            if (enemyPatrol != null)
            {
                enemyPatrol.ApplySlow(0.75f, 2f); // 50% slow for 2 seconds
            }
            hitEnemies.Add(collision);
        }
    }
    else if (hit && collision.CompareTag("Player"))
    {
            // Coming back and touching the player
        playerMovement.canMove = true;
        gameObject.SetActive(false);
    }
    else
    {
        // Any other object (e.g., wall), trigger return
        hit = true;
        boxcollider.enabled = false;
    }
}

    public void setDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxcollider.enabled = true;
        playerMovement.canMove = false;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

        hitEnemies.Clear();
    }

    public void Return()
    {
        Vector2 target = new Vector2(player.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, target, dendrospeed * Time.deltaTime);

        if (!boxcollider.enabled)
        boxcollider.enabled = true;
    }
}

