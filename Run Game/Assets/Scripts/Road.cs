using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Road : MonoBehaviour, IHitable
{
    [SerializeField] UnityEvent callback;

    public void Activate()
    {
        if (callback != null)
        {
            callback.Invoke();
        }
    }
}