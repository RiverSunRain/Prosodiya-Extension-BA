using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_audio_script : MonoBehaviour
{
    public AudioClip MusicClip;

    public AudioSource MusicSource;

    public AudioClip PositiveFeedbackSoundClip;
    public AudioSource PositiveFeedbackSoundSource;

    // Use this for initialization
    public void PlayAudioClip()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }

    public void PlayPositiveFeedback() {
        PositiveFeedbackSoundSource.clip = PositiveFeedbackSoundClip;
        PositiveFeedbackSoundSource.Play();
    }
}