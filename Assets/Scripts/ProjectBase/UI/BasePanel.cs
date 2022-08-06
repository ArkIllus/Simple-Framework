using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// ������
/// 1.�ҵ������Լ�����µĿؼ�������ӵ��ֵ�
/// 2.�ṩ��ʾ�����ص���Ϊ
/// </summary>
public class BasePanel : MonoBehaviour
{
    //������ϵ�����UI�ؼ���UIBehaviour��
    private Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();

    protected virtual void Awake()
    {
        FindChildrenControl<Button>();
        FindChildrenControl<Image>();
        FindChildrenControl<Text>();
        FindChildrenControl<Toggle>();
        FindChildrenControl<ScrollRect>();
        FindChildrenControl<Slider>();
        FindChildrenControl<InputField>();
        // ...
    }

    //��ʾ ʱ��Ҫ�����£�����UIManger��ShowPanel�е��ã�
    public virtual void ShowMe()
    {

    }
    //���� ʱ��Ҫ�����£�����UIManger��HidePanel�е��ã�
    public virtual void HideMe()
    {

    }

    //�����Զ�ע�ᰴťonClick�¼�
    protected virtual void OnClick(string btnName)
    {

    }
    //�����Զ�ע��Toggle��onValueChanged�¼�
    protected virtual void OnValueChanged_toggle(string toggleName, bool value)
    {

    }
    //InputField...

    //��������T���͵Ŀؼ�����ӵ��ֵ�
    private void FindChildrenControl<T>() where T: UIBehaviour
    {
        T[] controls = GetComponentsInChildren<T>();
        for (int i = 0; i < controls.Length; i++)
        {
            string objName = controls[i].gameObject.name;
            if (controlDic.ContainsKey(objName))
            {
                controlDic[objName].Add(controls[i]);
            }
            else
            {
                controlDic.Add(objName, new List<UIBehaviour>() { controls[i] });
            }

            //����ǰ�ť�ؼ����Զ�ע�ᰴťonClick�¼�
            if (controls[i] is Button)
            {
                (controls[i] as Button).onClick.AddListener(() =>
                {
                    OnClick(objName);
                });
            }
            else if (controls[i] is Toggle)
            {
                (controls[i] as Toggle).onValueChanged.AddListener((value) =>
                {
                    OnValueChanged_toggle(objName, value);
                });
            }
            else if (controls[i] is InputField)
            {
                //TODO
                //(controls[i] as InputField).onValueChanged.AddListener((value) =>
                //{
                //});
            }
            //...
        }
    }

    //��ȡT���͵���ΪcontrolName�Ŀؼ�
    protected T GetControl<T>(string controlName) where T: UIBehaviour
    {
        if (controlDic.ContainsKey(controlName))
        {
            for (int i = 0; i < controlDic[controlName].Count; i++)
            {
                if (controlDic[controlName][i] is T)
                    return controlDic[controlName][i] as T;
            }
        }
        return null;
    }
}
