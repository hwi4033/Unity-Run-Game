using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum EventType
{
    START,
    CONTINUE,
    PAUSE,
    STOP
}

public class EventManager
{
    private static readonly IDictionary<EventType, UnityEvent> dictionary = new Dictionary<EventType, UnityEvent>();

    public static void Subscribe(EventType eventType, UnityAction unityAction)
    {
        UnityEvent unityEvent;

        if (dictionary.TryGetValue(eventType, out unityEvent) == false)
        {
            dictionary.Add(eventType, unityEvent);
        }

        unityEvent.AddListener(unityAction);
    }

    public static void Unsubscribe(EventType eventType, UnityAction unityAction)
    {

    }

    public static void Publisher(EventType eventType)
    {

    }
}