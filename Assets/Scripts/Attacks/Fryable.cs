using UnityEngine;

public class Fryable : MonoBehaviour
{
    public saw_script saw;
    public void StartFrying()
    {
        saw = GetComponent<saw_script>();
        saw.DisableSaw();
    }

}
