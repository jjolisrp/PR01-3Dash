using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSoundEffect : MonoBehaviour
{
    AudioSource musicLvl;

    float restValue = 0.01f;

    bool applyEffect;

    private void OnEnable()
    {
        PlayerController.PlayerDied += MusicDieEffect;
        PlayerController.PlayerRestarted += ReturnToNormal;
    }

    void Start()
    {
        musicLvl = GetComponent<AudioSource>();

        applyEffect = false;
    }

    void Update()
    {
        if(applyEffect && musicLvl.pitch > 0)
        {
            musicLvl.pitch = musicLvl.pitch - restValue;
        }

        if(musicLvl.pitch < 0)
        {
            musicLvl.pitch = 0;
        }
    }

    void MusicDieEffect()
    {
        applyEffect = true;
    }

    void ReturnToNormal()
    {
        musicLvl.pitch = 1;
        musicLvl.Play();
        applyEffect = false;
    }

    private void OnDisable()
    {
        PlayerController.PlayerDied -= MusicDieEffect;
        PlayerController.PlayerRestarted -= ReturnToNormal;
    }
}
