using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Mono�Ĺ�����
/// ��û�м̳�MonoBehaviour�Ķ���ĺ���Ҳ��֡���£�Update��
/// </summary>
public class MonoController : MonoBehaviour
{
    private event UnityAction updateEvent;

    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if (updateEvent != null)
        {
            //updateEvent();
            updateEvent.Invoke();
        }
    }

    //���ⲿ�ṩ�� ���֡�����¼��ĺ���
    public void AddUpdateListener(UnityAction fun)
    {
        updateEvent += fun; 
    }

    //���ⲿ�ṩ�� �Ƴ�֡�����¼��ĺ���
    public void RemoveUpdateListener(UnityAction fun)
    {
        updateEvent -= fun;
    }
}
