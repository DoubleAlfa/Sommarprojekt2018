using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Script som hanterar alla ljud i spelet

    [SerializeField]
    AudioSource _musicSource, _efxSource;
    [SerializeField]
    static SoundManager _instance = null;

    void Awake() //Ser till att endast en instans av soundmanagern finns i scenen
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject); //Hindrar att soundmanagern förstörs vid scenomladdning
    }

    public void PlayMusic(AudioClip music) //För att spela upp musik
    {
        _musicSource.clip = music;
        _musicSource.Play();
    }

    public void PlaySoundEfx(AudioClip efx) //För att spela upp ljudeffekter
    {
        _efxSource.clip = efx;
        _efxSource.Play();
    }

}
