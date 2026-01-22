using UnityEngine;
using UnityEngine.UI;

public class MMSelectionArrow : MonoBehaviour
{
    private RectTransform rect;
    public RectTransform[] options;
    private int currentOpt;
    public AudioClip changeSound;
    public AudioClip interactSound;

    private void Awake()
    {
        rect = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            ChangePosition(-1);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            ChangePosition(1);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Interact();
        }

    }
    private void ChangePosition(int _change)
    {
        currentOpt += _change;

        if (_change != 0)
        {
            SoundManager.instance.PlaySound(changeSound);
        }

        if (currentOpt < 0)
        {
            currentOpt = options.Length - 1;
        }
        else if (currentOpt > options.Length - 1)
        {
            currentOpt = 0;
        }
        rect.position = new Vector3(rect.position.x, options[currentOpt].position.y, 0);
    }

    private void Interact()
    {
        SoundManager.instance.PlaySound(interactSound);

        options[currentOpt].GetComponent<Button>().onClick.Invoke();
    }
}
