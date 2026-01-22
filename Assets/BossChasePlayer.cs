using UnityEngine;

public class BossChasePlayer : MonoBehaviour
{
    public Transform player;
    public float chaseSpeed = 5f;

    private Camera mainCamera;
    private Animator animator;

    // Hysteresis: delay before toggling animation
    public float animationToggleDelay = 0.2f; // seconds
    private float toggleTimer = 0f;
    private bool lastVisibilityState = false;

    private void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        lastVisibilityState = IsVisibleOnScreen();
    }

    private void Update()
    {
        bool isVisibleNow = IsVisibleOnScreen();

        // Update toggle timer
        if (isVisibleNow != lastVisibilityState)
        {
            toggleTimer += Time.deltaTime;
            if (toggleTimer >= animationToggleDelay)
            {
                // State changed: update animation
                if (animator != null)
                    animator.SetBool("isRunning", !isVisibleNow);

                // Reset state tracking
                lastVisibilityState = isVisibleNow;
                toggleTimer = 0f;
            }
        }
        else
        {
            // Reset timer if state hasn't changed
            toggleTimer = 0f;
        }

        if (!isVisibleNow)
        {
            // Chase the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
        }
    }

    private bool IsVisibleOnScreen()
    {
        Vector3 viewportPos = mainCamera.WorldToViewportPoint(transform.position);

        // Using a smaller margin for tight visibility check
        float margin = -0.2f;
        return viewportPos.z > 0 &&
               viewportPos.x > -margin && viewportPos.x < 1f + margin &&
               viewportPos.y > -margin && viewportPos.y < 1f + margin;
    }
}
