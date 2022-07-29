using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��Դ����ģ��
/// TODO:AssetBundle
/// </summary>
public class ResourceManager : BaseManager<ResourceManager>
{
    //ͬ��������Դ
    public T Load<T>(string name) where T : Object
    {
        T res = Resources.Load<T>(name);
        //���������GameObject���ͣ�����ʵ�������ٷ��س�ȥ
        if (res is GameObject)
        {
            return GameObject.Instantiate(res) as T;
        }
        else
        {
            return res;
        }
    }

    //�첽������Դ
    public void LoadAsync<T>(string name, UnityAction<T> callback) where T: Object
    {
        //�����첽���ص�Э��
        //Resources.LoadAsync(name); //��
        MonoManager.GetInstance().StartCoroutine(ReallyLoadAsync(name, callback));
    }

    //������Э�̺��� ���ڿ������ض�Ӧ����Դ
    private IEnumerator ReallyLoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        ResourceRequest r = Resources.LoadAsync<T>(name);
        yield return r;

        if (r.asset is GameObject)
        {
            //���������GameObject���ͣ�����ʵ�������ٷ��س�ȥ
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            callback(r.asset as T);
        }
    }
}
