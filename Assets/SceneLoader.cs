using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public float timer = 5f;
    public float countdown = 0f;

    private void Update()
    {
        countdown += Time.deltaTime;
        if (countdown >= timer)
        {
            SceneManager.LoadScene(0);
        }
    }
}
