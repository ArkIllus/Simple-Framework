using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInput : MonoBehaviour
{
    void Start()
    {
        InputManager.GetInstance().StartOrEndCheck(true);

        EventCenter.GetInstance().AddEventListener<KeyCode>("keyDown", CheckInputDown);
        EventCenter.GetInstance().AddEventListener<KeyCode>("keyUp", CheckInputUp);
    }

    private void CheckInputDown(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.W:
                Debug.Log("w down");
                break;
            case KeyCode.A:
                Debug.Log("a down");
                break;
            case KeyCode.D:
                Debug.Log("s down");
                break;
            case KeyCode.S:
                Debug.Log("d down");
                break;
        }
    }
    private void CheckInputUp(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.W:
                Debug.Log("w up");
                break;
            case KeyCode.A:
                Debug.Log("a up");
                break;
            case KeyCode.D:
                Debug.Log("s up");
                break;
            case KeyCode.S:
                Debug.Log("d up");
                break;
        }
    }
}
