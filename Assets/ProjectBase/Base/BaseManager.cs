using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: ˫��double lock
// ���̳�MonoBehaviour
public class BaseManager<T> where T : new()
{
    private static T instance;

    //���������˽�л�(protected)���캯��
    protected BaseManager()
    {

    }

    public static T GetInstance()
    {
        if(instance == null)
        {
            instance = new T();
        }
        return instance;
    }
}
