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
        //现在无需再为按钮注册事件了
        //GetControl<Button>("Button Start").onClick.AddListener(ClickStart);
        //GetControl<Button>("Button Quit").onClick.AddListener(ClickQuit);
    }

    protected override void OnClick(string btnName)
    {
        switch (btnName) 
        {
            case "Button Start":
                Debug.Log("Button Start被点击");
                break;
            case "Button Quit":
                Debug.Log("Button Quit被点击");
                break;
        }
    }

    protected override void OnValueChanged_toggle(string btnName, bool value)
    {
        //...同上
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
