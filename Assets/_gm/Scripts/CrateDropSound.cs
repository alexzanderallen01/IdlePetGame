using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDropSound : MonoBehaviour
{
    //create vars for a sound asset & a sound object source
    public AudioSource _soundAudioSource;
    public AudioClip _soundClip;
    private void OnCollisionEnter(Collision collision)
    {
        PlaySoundEffect();//When collision with a mesh, use function
    }
    void PlaySoundEffect(){//set clip tp soundClip & play it. Turn volume down to 5%
        _soundAudioSource.clip = _soundClip;
        _soundAudioSource.Play();
        _soundAudioSource.volume = 0.05f;
    }
}
