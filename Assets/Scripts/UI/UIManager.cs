using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public Image gameOverBackground;
    public AudioClip gameOverSound;
    public AudioClip mainTheme;
    public Text tutorialTextUI;
    public GameObject healthbar;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }
    public void GameOver()
    {
        if (tutorialTextUI != null)
        {
            tutorialTextUI.gameObject.SetActive(false);
        }
        if (healthbar != null)
        {
            healthbar.SetActive(false);
        }
        
        gameOverScreen.SetActive(true);
        if (gameOverBackground != null)
        {
            gameOverBackground.gameObject.SetActive(true);
        }
        SoundManager.instance.StopAll();
        SoundManager.instance.PlaySound(gameOverSound);
    }
    public void Restart()
    {
        if (tutorialTextUI != null)
        {
            tutorialTextUI.gameObject.SetActive(true);
        }
        if (healthbar != null)
        {
            healthbar.SetActive(true);
        }
        if (gameOverBackground != null)
        {
            gameOverBackground.gameObject.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.instance.RestartMainTheme(mainTheme);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        SoundManager.instance.PlaySound(mainTheme);
    }
}

