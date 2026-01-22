using UnityEngine;

public class BossShootHoming : MonoBehaviour
{
    public Transform player; // Reference to the player
    public GameObject projectilePrefab; // Your projectile prefab
    public Transform shootPoint; // Where to spawn the projectile

    public float shootInterval = 2f; // Fire every 2 seconds
    private float shootTimer = 0f;

    private void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            ShootHomingProjectile();
            shootTimer = 0f;
        }
    }

    private void ShootHomingProjectile()
    {
        // Instantiate the projectile
        GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.LookRotation(player.position - shootPoint.position));
        Destroy(projectile, 5f);

        // Assign the target
        HomingProjectile homingScript = projectile.GetComponent<HomingProjectile>();
        if (homingScript != null)
        {
            homingScript.target = player;
        }
    }
}
