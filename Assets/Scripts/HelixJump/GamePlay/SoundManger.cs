using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManger : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceMain;
    [SerializeField] AudioSource AudioSourceBG;

    [SerializeField] AudioClip BackgroundMusic;

    [Range(0, 1)] public float Volume;
    public void PlaySound(AudioClip clip)
    {
        audioSourceMain.clip = clip;
        audioSourceMain.Play();
    }

    private void Start()
    {
        Volume = .15f;
        AudioSourceBG.clip=BackgroundMusic;
        AudioSourceBG.Play();
        AudioSourceBG.volume = Volume;
        AudioSourceBG.loop = true;
    }
}
