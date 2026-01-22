using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    [Header("Attack Parameters")]
    public float attackCooldown;
    public int damage;
    private float cooldownTimer = Mathf.Infinity;
    private bool isShooting = false;

    [Header("Collider Parameters")]
    public BoxCollider2D boxCollider;
    public float range;
    public float colliderDistance;

    [Header("Player Layer")]
    public LayerMask playerLayer;

    [Header("References")]
    private Animator anim;
    private EnemyPatrol enemyPatrol;

    [Header("Ranged Attack")]
    public Transform firePoint;
    public GameObject[] fireballs;

    [Header("Burst Parameters")]
    public int burstCount = 3;          // Number of shots per burst
    public float burstDelay = 0.3f;     // Delay between shots in burst

    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (PlayerInSight())
        {
            if (cooldownTimer >= attackCooldown && !isShooting)
            {
                StartCoroutine(BurstAttack());
                anim.SetTrigger("Ranged");
            }
        }

        if (enemyPatrol != null)
        {
            enemyPatrol.enabled = !PlayerInSight();
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0, Vector2.left, 0, playerLayer);

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private System.Collections.IEnumerator BurstAttack()
    {
        isShooting = true; // ADDED
        cooldownTimer = 0; // ADDED: Reset cooldown at burst start

        for (int i = 0; i < burstCount; i++) // ADDED: Loop for burst
        {
            anim.SetTrigger("Ranged"); // ADDED: Trigger shot
            yield return new WaitForSeconds(burstDelay); // ADDED: Delay between burst shots
        }

        isShooting = false; // ADDED: End burst
    }

    private void RangedAttack()
    {
        cooldownTimer = 0;
        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<EnemyProjectile>().ActivateProjectile();
    }

    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;
    }
}
