using System.Collections;
using UnityEngine;

public class CutsceneSequence : MonoBehaviour
{
    public Animator[] animators;
    public string[] clipNames;
    public float delay = 1.2f;

    void start()
    {
        StartCoroutine(PlayCutScene());
    }

    IEnumerator PlayCutScene()
    {
        for (int i = 0; i < animators.Length; i++)
        {
            animators[i].Play(clipNames[i]);
            yield return new WaitForSeconds(delay);
        }
    }
}
