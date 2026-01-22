using UnityEngine;

public class BombFall : MonoBehaviour
{
    public float warningTime = 3f;  // How long to stay in the warning position
    public float minX = 135f;
    public float maxX = 157f;

    public GameObject bombPrefab;  // Use prefab for bomb
    public GameObject topPoint;    // Reference to top point (where the bomb spawns)

    private float warningTimer;

    public GameObject newBomb;

    private void Start()
    {
        // Start with the teleport
        TeleportToRandomX();
        warningTimer = warningTime;
    }

    private void Update()
    {
        warningTimer -= Time.deltaTime;

        if (warningTimer <= 0f)
        {
            DropBomb();
            // Teleport to a new position immediately for the next cycle
            TeleportToRandomX();
            warningTimer = warningTime;
        }
    }

    private void TeleportToRandomX()
    {
        float y = transform.position.y;
        float z = transform.position.z;
        float randomX = Random.Range(minX, maxX);

        transform.position = new Vector3(randomX, y, z);
    }

    private void DropBomb()
    {
        // Instantiate a new bomb at the topPoint’s position
        GameObject newBomb = Instantiate(bombPrefab, topPoint.transform.position, Quaternion.identity);
        Destroy(newBomb, 5f);
    }
}
