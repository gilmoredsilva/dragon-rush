using UnityEngine;
using UnityEngine.SceneManagement;

public class MMUIManager : MonoBehaviour
{
    public GameObject mainScreen;
    public AudioClip mainTheme;

    private void Awake()
    {
        mainScreen.SetActive(true);
        if (!SoundManager.instance.IsPlaying(mainTheme.name))
        {
            SoundManager.instance.PlayLoopMusic(mainTheme);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Credits()
    {
        SceneManager.LoadScene(4);
    }
}
