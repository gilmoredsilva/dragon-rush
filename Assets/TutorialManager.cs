using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;
    public Text tutorialTextUI;

    private void Awake()
    {
        tutorialTextUI.gameObject.SetActive(true);
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowText(string newText)
    {
        tutorialTextUI.text = newText;
    }
}
