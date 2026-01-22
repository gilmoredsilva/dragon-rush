using UnityEngine;

public class BossBombDrop : MonoBehaviour
{
    public float warningTime = 3f;  // How long to stay in the warning position
    public float moveTime = 5f;
    public Transform player;
    public GameObject bombPrefab;  // Use prefab for bomb
    public GameObject topPoint;    // Reference to top point (where the bomb spawns)

    private float warningTimer;
    private float moveTimer = 0f;

    public GameObject newBomb;

    private void Start()
    {
        // Start with the teleport
        gameObject.SetActive(false);
        warningTimer = warningTime;
    }

    private void Update()
    {
        warningTimer -= Time.deltaTime;
        moveTimer += Time.deltaTime;

        if (warningTimer <= 0f)
        {
            DropBomb();
            // Teleport to a new position immediately for the next cycle
            warningTimer = warningTime;
        }
        if (moveTimer >= moveTime)
        {
            transform.position = new Vector3(player.position.x - 3f, -0.27f, player.position.z);
        }
    }
    private void DropBomb()
    {
        // Instantiate a new bomb at the topPoint’s position
        GameObject newBomb = Instantiate(bombPrefab, topPoint.transform.position, Quaternion.identity);
        Destroy(newBomb, 5f);
    }
}
