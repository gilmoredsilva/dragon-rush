using UnityEngine;

public class BossMechanics : MonoBehaviour
{
    private Health health;
    public Transform player;
    public GameObject minionPrefab;
    public GameObject bombdispPrefab;
    public Transform shootPoint;
    public Transform spawnPoint;
    public float enemyInterval = 4f;
    private float enemyTimer = 0f;
    public float bombInterval = 5f;
    private float bombTimer = 0f;
    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        if (health.currentHealth < 75)
        {
            enemyTimer += Time.deltaTime;

            if (enemyTimer >= enemyInterval)
            {
                SpawnMelee();
                enemyTimer = 0f;
            }
        }
        if (health.currentHealth < 50)
        {
            bombTimer += Time.deltaTime;
            if (bombTimer >= bombInterval)
            {
                DropBombs();
                bombTimer = 0;
            }
        }
    }

    private void SpawnMelee()
    {
        GameObject minion = Instantiate(minionPrefab, spawnPoint.position, Quaternion.Euler(0, 0, 0));
    }
    private void DropBombs()
    {
        bombdispPrefab.gameObject.SetActive(true);
        bombdispPrefab.transform.position = new Vector3(player.position.x, -0.27f, player.position.z);
    }
}
