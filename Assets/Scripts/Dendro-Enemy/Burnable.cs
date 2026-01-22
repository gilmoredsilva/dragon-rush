using UnityEngine;

public class Burnable : MonoBehaviour
{
    public void StartBurning()
    {
        DarkDendro dark = GetComponent<DarkDendro>();
        dark?.DrainHealth();
        Destroy(gameObject);
    }
}
