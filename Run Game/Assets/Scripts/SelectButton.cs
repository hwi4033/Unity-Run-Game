using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    [SerializeField] Text buttonText;
    [SerializeField] AudioClip enterAudioClip;

    private void Awake()
    {
        buttonText = GetComponentInChildren<Text>();
    }

    public void OnEnter()
    {
        buttonText.fontSize = 85;
        buttonText.color = Color.red;

        AudioManager.Instance.Listen(enterAudioClip);
    }

    public void OnLeave()
    {
        buttonText.fontSize = 75;
        buttonText.color = Color.black;
    }

    public void OnSelect()
    {
        buttonText.fontSize = 50;
    }
}
