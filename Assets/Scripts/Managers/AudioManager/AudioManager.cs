using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType
{
    StickMovement,
    BallHoleInteraction
}

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSO[] soundsSoArray;
    [SerializeField] private AudioClip[] backgroudMusics;
    private AudioSource source;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
        SoundConfiguration();
    }
    private void OnEnable()
    {
        HoleInteraction.OnHoleInteractionSound += PlaySound;
        ButtonBase.OnStickButtonSound += PlaySound;
    }
    private void OnDisable()
    {
        ButtonBase.OnStickButtonSound -= PlaySound;
        HoleInteraction.OnHoleInteractionSound -= PlaySound;

    }

    private void PlayRandomBackgroundMusic()
    {
        AudioClip clip = backgroudMusics[UnityEngine.Random.Range(0, backgroudMusics.Length)];
        source.clip = clip;
        source.Play();
    }

    private void SoundConfiguration()
    {
        foreach (var sound in soundsSoArray)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.playOnAwake = sound.playOnAwake;
            sound.audioSource.loop = sound.loop;
        }
    }
    public void PlaySound(SoundType soundType, bool state)
    {
        AudioSO audio = Array.Find(soundsSoArray, sound => sound.soundType == soundType);

        if (state)
        {
            if (audio == null)
                return;
            audio.audioSource.Play();
        }
        else
            audio.audioSource.Stop();

    }
}
