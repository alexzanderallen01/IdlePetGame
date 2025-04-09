using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds_MGR : MonoBehaviour
{
    public AudioSource _musicAudioSource;
    public AudioClip _musicClip;

    private void Start()
    {
        waiter();
        PlayMusic();
    }
    //Doesn't work???
    IEnumerable waiter(){
        yield return new WaitForSeconds(50);
    }
    void PlayMusic(){
        _musicAudioSource.clip = _musicClip;
        _musicAudioSource.Play();
        _musicAudioSource.volume = 0.15f;
    }
}
