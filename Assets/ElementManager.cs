using UnityEngine;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{
    public PlayerElement elem;
    public Text elementDisp;

    void Update()
    {
        elementDisp.text = "" + elem.currentElement;
    }
    
}
