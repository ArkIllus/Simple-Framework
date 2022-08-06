using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Internal; //[DefaultValue("null")]

/// <summary>
/// 1.�����ṩ���ⲿ���֡�����¼��ķ���
/// 2.�����ṩ���ⲿ���Э�̵ķ���
/// </summary>
public class MonoManager : BaseManager<MonoManager>
{
    private MonoController controller;

    //constructor
    public MonoManager()
    {
        //��֤��MonoController�����Ψһ��
        GameObject obj = new GameObject("MonoController");
        controller = obj.AddComponent<MonoController>();
    }

    //���ⲿ�ṩ�� ���֡�����¼��ĺ���
    public void AddUpdateListener(UnityAction fun)
    {
        controller.AddUpdateListener(fun);
    }

    //���ⲿ�ṩ�� �Ƴ�֡�����¼��ĺ���
    public void RemoveUpdateListener(UnityAction fun)
    {
        controller.RemoveUpdateListener(fun);
    }

    public Coroutine StartCoroutine(IEnumerator routine)
    {
        return controller.StartCoroutine(routine);
    }

    public Coroutine StartCoroutine(string methodName, [DefaultValue("null")] object value)
    {
        return controller.StartCoroutine(methodName, value);
    }

    public Coroutine StartCoroutine(string methodName)
    {
        return controller.StartCoroutine(methodName);
    }

    //�����Է�װStopCoroutine etc...
}
