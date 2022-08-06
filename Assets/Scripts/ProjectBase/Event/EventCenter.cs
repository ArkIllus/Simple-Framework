using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IEventInfo
{
    
}

public class EventInfo<T>: IEventInfo
{
    public UnityAction<T> actions;

    //constructor
    public EventInfo(UnityAction<T> action)
    {
        this.actions += action;
    }
}
public class EventInfo : IEventInfo
{
    public UnityAction actions;

    //constructor
    public EventInfo(UnityAction action)
    {
        this.actions += action;
    }
}

/// <summary>
/// �¼�����
/// TODO: UnityAction? Action?���ܶԱ�
/// </summary>
public class EventCenter : BaseManager<EventCenter> //EventCenter<T>�Ͳ����ˣ�������͵�����ͻ
{
    //key �¼�������
    //value �������¼��Ķ�Ӧί�к���
    //<object>�����κ����͵Ķ��������ȱ����ֵ���ͻ�װ��
    //����<IEventInfo>������װ�����
    //private Dictionary<string, UnityAction<object>> eventDic = new Dictionary<string, UnityAction<object>>();
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    //����¼�����
    public void AddEventListener<T>(string name, UnityAction<T> action)
    {
        if (!eventDic.ContainsKey(name))
        {
            //eventDic.Add(name, action);
            eventDic.Add(name, new EventInfo<T>(action));
        }
        else
        {
            (eventDic[name] as EventInfo<T>).actions += action;
            //eventDic[name] += action;
        }
    }
    //����¼�����(���� ����Ҫ�������¼�)
    public void AddEventListener(string name, UnityAction action)
    {
        if (!eventDic.ContainsKey(name))
        {
            //eventDic.Add(name, action);
            eventDic.Add(name, new EventInfo(action));
        }
        else
        {
            (eventDic[name] as EventInfo).actions += action;
            //eventDic[name] += action;
        }
    }

    //�Ƴ��¼�����
    public void RemoveEventListener<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name] -= action;
            (eventDic[name] as EventInfo<T>).actions -= action;
        }
    }
    //�Ƴ��¼�����(���� ����Ҫ�������¼�)
    public void RemoveEventListener(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name] -= action;
            (eventDic[name] as EventInfo).actions -= action;
        }
    }

    /// <summary>
    /// �¼�����
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="info"></param>
    public void EventTrigger<T>(string name, T info)
    {
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name](info);
            //eventDic[name].Invoke(info);
            (eventDic[name] as EventInfo<T>).actions?.Invoke(info);
        }
    }

    /// <summary>
    /// �¼�����(���� ����Ҫ�������¼�)
    /// </summary>
    /// <param name="name">�¼���</param>
    /// <param name="info"></param>
    public void EventTrigger(string name)
    {
        if (eventDic.ContainsKey(name))
        {
            //eventDic[name](info);
            //eventDic[name].Invoke(info);
            (eventDic[name] as EventInfo).actions?.Invoke();
        }
    }

    //����¼�����
    //��Ҫ���ڳ����л�ʱ
    public void Clear()
    {
        eventDic.Clear();
    }
}
