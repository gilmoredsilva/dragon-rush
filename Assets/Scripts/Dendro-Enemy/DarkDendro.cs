using UnityEngine;

public class DarkDendro : MonoBehaviour
{
    public int dendroDamage = 1;

    public void DrainHealth()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Health ph = player.GetComponent<Health>();
            ph?.TakeDamage(dendroDamage);
        }
    }
}
