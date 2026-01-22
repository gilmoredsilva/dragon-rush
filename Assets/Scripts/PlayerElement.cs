using UnityEngine;

public enum ElementType { Pyro, Hydro, Electro, Dendro }

public class PlayerElement : MonoBehaviour
{
    public ElementType currentElement = ElementType.Pyro;
    public int type = 0;

    [Header("Visuals")]
    public Sprite fireball;
    public Sprite waterball;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ToggleElement(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ToggleElement(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleElement(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            ToggleElement(3);
        }

        void ToggleElement(int pressedNum)
        {
            type = pressedNum;
            if (pressedNum == 0)
            {
                currentElement = ElementType.Pyro;
            }
            else if (pressedNum == 1)
            {
                currentElement = ElementType.Hydro;
            }
            else if (pressedNum == 2)
            {
                currentElement = ElementType.Electro;
            }
            else if (pressedNum == 3)
            {
                currentElement = ElementType.Dendro;
            }

            Debug.Log("Switched to: " + currentElement);
        }
    }
}
