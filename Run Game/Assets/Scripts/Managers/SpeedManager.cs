using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeedManager : State
{
    [SerializeField] float speed = 30.0f;
    [SerializeField] float limitSpeed = 75.0f;

    [SerializeField] float increaseValue = 5.0f;

    public float Speed
    {
        get { return speed; }
    }

    private void Awake()
    {
        StartCoroutine(Increase());
    }

    public IEnumerator Increase()
    {
        while (state == true && speed < limitSpeed)
        {
            yield return CoroutineCache.WaitForSecond(10);

            speed += increaseValue;
        }
    }
}