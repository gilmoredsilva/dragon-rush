using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header ("Patrol Points")]
    public Transform leftEdge;
    public Transform rightEdge;

    [Header("Enemy")]
    public Transform enemy;
    public Animator anim;

    [Header("Movement Parameters")]
    public float enemySpeed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Idle Time")]
    public float idleDuration;
    private float idleTimer;

    [Header("Slow")]
    private float originalSpeed;
    public float moveSpeed = 2f;
    private bool isSlowed = false;
    private float slowTimer = 0f;

    private void Awake()
    {
        initScale = enemy.localScale;
        moveSpeed = enemySpeed;
        originalSpeed = enemySpeed;
    }

    public void ApplySlow(float slowAmount, float duration)
    {
        if (!isSlowed)
        {
            moveSpeed *= (1f - slowAmount); // e.g., slowAmount = 0.5 for 50% slow
            isSlowed = true;
            slowTimer = duration;
        }
    }

    private void OnDisable()
    {
        anim.SetBool("Moving", false);
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MovementDirection(-1);
            }
            else
            {
                DirectionChange();
            }

        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MovementDirection(1);
            }
            else
            {
                DirectionChange();
            }
        }

        if (isSlowed)
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0f)
            {
                moveSpeed = originalSpeed;
                isSlowed = false;
            }
        }
    }

    private void DirectionChange()
    {
        anim.SetBool("Moving", false);
        idleTimer += Time.deltaTime;
        if (idleTimer > idleDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MovementDirection(int _direction)
    {
        idleTimer = 0;
        anim.SetBool("Moving", true);
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _direction, initScale.y, initScale.z);
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * moveSpeed, enemy.position.y, enemy.position.z);
    }
}
