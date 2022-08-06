using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ʹ��InputManager���������ģ��
/// TODO:InputSystem
/// </summary>
public class InputManager : BaseManager<InputManager>
{
    private bool isChecking = false;

    //constructor
    public InputManager()
    {
        MonoManager.GetInstance().AddUpdateListener(UpdateAllInputs);
    }

    /// <summary>
    /// ������ر�������
    /// </summary>
    public void StartOrEndCheck(bool isCheck)
    {
        isChecking = isCheck;
    }

    private void UpdateAllInputs()
    {
        if (!isChecking)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.D);
    }

    /// <summary>
    /// �����̰���̧�𡢰���
    /// </summary>
    /// <param name="key"></param>
    private void CheckKeyCode(KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            EventCenter.GetInstance().EventTrigger("keyDown", key);
        }
        if (Input.GetKeyUp(key))
        {
            EventCenter.GetInstance().EventTrigger("keyUp", key);
        }
    }
}
