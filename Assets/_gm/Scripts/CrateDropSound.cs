using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDropSound : MonoBehaviour
{
    public AudioSource _soundAudioSource;
    public AudioClip _soundClip;
    private void OnCollisionEnter(Collision collision)
    {
        PlaySoundEffect();
    }
    void PlaySoundEffect(){
        _soundAudioSource.clip = _soundClip;
        _soundAudioSource.Play();
        _soundAudioSource.volume = 0.05f;
    }
}
