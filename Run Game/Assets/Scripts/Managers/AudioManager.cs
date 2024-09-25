using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioSource sceneryAudioSource;
    [SerializeField] AudioSource effectAudioSource;

    public void Listen(AudioClip audioClip)
    {
        effectAudioSource.PlayOneShot(audioClip);
    }
}