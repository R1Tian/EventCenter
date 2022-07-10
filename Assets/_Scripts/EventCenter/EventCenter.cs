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

    //存储所有已注册UnityAction的字典
    private Dictionary<string, IEventInfo> eventDic = new Dictionary<string, IEventInfo>();

    //添加事件 无泛型
    public void RegistEvent(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name)) //如果这个action已经注册过了
            (eventDic[name] as EventInfo).action += action;
        else
            eventDic.Add(name, new EventInfo() { action = action});

    }

    //添加事件 有泛型
    public void RegistEvent<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name)) //如果这个action已经注册过了
            (eventDic[name] as EventInfo<T>).action += action;
        else
            eventDic.Add(name, new EventInfo<T>() { action = action });

    }

    //注销事件 无泛型
    public void unRegistEvent(string name, UnityAction action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo).action -= action;
    }

    //注销事件 有泛型
    public void unRegistEvent<T>(string name, UnityAction<T> action)
    {
        if (eventDic.ContainsKey(name))
            (eventDic[name] as EventInfo<T>).action -= action;
    }

    //触发事件 无泛型
    public void triggerEvent(string name)
    {
        if(eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo).action?.Invoke();
        }
    }

    //触发事件 有泛型
    public void triggerEvent<T>(string name, T arg)
    {
        if (eventDic.ContainsKey(name))
        {
            (eventDic[name] as EventInfo<T>).action?.Invoke(arg);
        }
    }

    //清空eventDic
    public void ClearEventDic()
    {
        eventDic.Clear();
    }

}
