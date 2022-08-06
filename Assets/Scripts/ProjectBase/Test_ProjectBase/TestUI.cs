using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUI : MonoBehaviour
{
    public static string loginPanel = "LoginPanel";

    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInstance().ShowPanel<LoginPanel>(loginPanel, E_UI_Layer.Mid, ShowPanelOver);
    }

    private void ShowPanelOver(LoginPanel panel)
    {
        panel.InitInfo();
        Invoke("DelayHide", 3);
    }


    public void DelayHide()
    {
        UIManager.GetInstance().HidePanel(loginPanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
