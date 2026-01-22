using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public AudioClip checkpointSound;
    private Transform current; //Current Checkpoint
    private Health playerHealth;
    private UIManager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<Health>();
        uiManager = FindFirstObjectByType<UIManager>();
    }

    private void CheckRespawn()
    {
        if (current == null)
        {
            uiManager.GameOver();
            return;
        }
        transform.position = current.position;
        playerHealth.Respawn();
        Camera.main.GetComponent<CameraController>().MoveToNewRoom(current.parent);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Checkpoint")
        {
            current = collision.transform;
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("Appear");
        }
    }
}
