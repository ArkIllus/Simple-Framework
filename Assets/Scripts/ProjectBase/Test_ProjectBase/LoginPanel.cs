using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    protected override void Awake()
    {
        base.Awake();
        //...
    }

    void Start()
    {
        //����������Ϊ��ťע���¼���
        //GetControl<Button>("Button Start").onClick.AddListener(ClickStart);
        //GetControl<Button>("Button Quit").onClick.AddListener(ClickQuit);
    }

    protected override void OnClick(string btnName)
    {
        switch (btnName) 
        {
            case "Button Start":
                Debug.Log("Button Start�����");
                break;
            case "Button Quit":
                Debug.Log("Button Quit�����");
                break;
        }
    }

    protected override void OnValueChanged_toggle(string btnName, bool value)
    {
        //...ͬ��
    }

    public void ClickStart()
    {
        //e.g.:
        //UIManager.GetInstance().ShowPanel<LoadingPanel>("LoadingPanel", E_UI_Layer.Bot);
        Debug.Log("start");
    }

    public void InitInfo()
    {
        Debug.Log("InitInfo");
    }

    public void ClickQuit()
    {
        Debug.Log("quit");
    }
}
