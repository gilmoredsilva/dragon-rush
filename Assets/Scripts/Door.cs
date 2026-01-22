using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform previousRoom;
    public Transform nextRoom;
    public CameraController cam;

    [TextArea]
    public string newTutorialText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TutorialManager.Instance.ShowText(newTutorialText);
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);
            }
        }
    }
}
