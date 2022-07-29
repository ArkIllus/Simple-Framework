using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// ��������
/// ��������Hierarchy�й۲죩
/// </summary>
public class PoolData
{
    //����List�ĸ�����
    public GameObject parentObj;
    //���������
    public List<GameObject> poolList;

    //constructor
    public PoolData(GameObject obj, GameObject poolObj)
    {
        //�������� = ����obj��
        this.parentObj = new GameObject(obj.name); 
        parentObj.transform.parent = poolObj.transform;
        poolList = new List<GameObject>() { };
        PushObj(obj);
    }

    public void PushObj(GameObject obj)
    {
        poolList.Add(obj);
        obj.transform.parent = parentObj.transform;
    }

    public GameObject GetObj()
    {
        GameObject obj = null;
        obj = poolList[0];
        poolList.RemoveAt(0);
        //��ʾ
        obj.SetActive(true);
        //��������Ϊ�գ�������Hierarchy�й۲죩
        obj.transform.parent = null;
        return obj;
    }
}

/// <summary>
/// �����ģ��
/// </summary>
public class PoolManager : BaseManager<PoolManager>
{
    //���������
    public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

    private GameObject poolObj;

    /// <summary>
    /// �����ö���
    /// </summary>
    /// <param name="name">��Դ·��</param>
    /// <param name="callBack">ȡ����Դ��Ļص�����</param>
    public void GetObj(string name, UnityAction<GameObject> callBack)
    {
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            callBack(poolDic[name].GetObj());
        }
        else
        {
            //�첽����
            ResourceManager.GetInstance().LoadAsync<GameObject>(name, (_obj) =>
            {
                //��������ָĳɳ��ӵ�����
                _obj.name = name;
                callBack(_obj);
            });
        }
    }

    /// <summary>
    /// ����涫��
    /// </summary>
    /// <param name="name">��gameObject������</param>
    /// <param name="obj">��gameObject</param>
    public void PushObj(string name, GameObject obj)
    {
        //����صĸ��ڵ����� ��ΪPool
        if (poolObj == null)
        {
            poolObj = new GameObject("Pool");
        }
        //���ø�����ΪPool���壨������Hierarchy�й۲죩
        obj.transform.parent = poolObj.transform;

        //����
        obj.SetActive(false);
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].PushObj(obj);
        }
        else
        {
            poolDic.Add(name, new PoolData(obj, poolObj));
        }
    }

    /// <summary>
    /// ��ջ����
    /// ��Ҫ���� �����л�ʱ
    /// </summary>
    public void Clear()
    {
        poolDic.Clear();
        poolObj = null;
    }
}
