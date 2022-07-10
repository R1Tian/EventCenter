using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public interface IEventInfo { }

public class EventInfo : IEventInfo
{
    public UnityAction action;
}

public class EventInfo<T> : IEventInfo
{
    public UnityAction<T> action;
}

public class EventCenter 
{
    private static EventCenter instance;

    public static EventCenter Instance
    {
        get
        {
            if (instance == null) instance = new EventCenter();
            return instance;
        }
    }

    //�洢������ע��UnityAction���ֵ�
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    //����¼� �޷���
    public void RegistEvent(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name)) //������action�Ѿ�ע�����
            (eventDic[name] as EventInfo).action += action;
        else
            eventDic.Add(name, new EventInfo() { action = action});

    }

    //����¼� �з���
    public void RegistEvent<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name)) //������action�Ѿ�ע�����
            (eventDic[name] as EventInfo<T>).action += action;
        else
            eventDic.Add(name, new EventInfo<T>() { action = action });

    }

    //ע���¼� �޷���
    public void unRegistEvent(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).action -= action;
    }

    //ע���¼� �з���
    public void unRegistEvent<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).action -= action;
    }

    //�����¼� �޷���
    public void triggerEvent(string name)
    {
        if(eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).action?.Invoke();
        }
    }

    //�����¼� �з���
    public void triggerEvent<T>(string name, T arg)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).action?.Invoke(arg);
        }
    }

    //���eventDic
    public void ClearEventDic()
    {
        eventDic.Clear();
    }

}
