using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̳�Monobehaviour
// ����ʱֱ��GetInstance���Զ�����GameObject
public class SingletonAutoMono<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T GetInstance()
    {
        if (instance == null)
        {
            //���ö��������Ϊ�ű���
            GameObject go = new GameObject();
            go.name = typeof(T).ToString();
            instance = go.AddComponent<T>();
            //��ѡ���õ���ģʽ���� ������ ���Ƴ�
            DontDestroyOnLoad(go);
        }
        return instance;
    }
}
