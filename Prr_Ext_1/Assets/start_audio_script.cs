using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_audio_script : MonoBehaviour
{
    public AudioClip MusicClip;

    public AudioSource MusicSource;

    //public AudioClip NegativeFeedbackSoundClip; // 18.04.19 Für negative sound version: einkommentieren
    public AudioClip PositiveFeedbackSoundClip;
    //public AudioSource PositiveFeedbackSoundSource;

   

    public List<AudioClip> PositiveFeedbackListClip;
    public AudioSource PositiveFeedbackSource;

    public List<AudioClip> NegativeFeedbackListClip;
    public AudioSource NegativeFeedbackSource;

    public AudioClip HelpAudioClip;
    public AudioSource HelpAudioSource;

    // Use this for initialization
    public void PlayAudioClip()
    {
        MusicSource.clip = MusicClip;
        MusicSource.Play();
    }

    /*
    public void PlayPositiveFeedbackSound() {

        PositiveFeedbackSoundSource.clip = PositiveFeedbackSoundClip;
        PositiveFeedbackSoundSource.Play();
    }
    **/
    public IEnumerator PlayPositiveFeedback()
    {
        var a1 = PositiveFeedbackSoundClip;
        var a2 = PositiveFeedbackListClip[Random.Range(0, 8)];
        StartCoroutine(playAudioSequentially(a1, a2));
        yield return StartCoroutine(playAudioSequentially(a1, a2));
        //PositiveFeedbackSource.clip = PositiveFeedbackListClip[Random.Range(0, 8)];
        //PositiveFeedbackSource.Play();
    }




    /* 18.04.19 Für negative sound version: einkommentieren
     * 
     * 
    public IEnumerator PlayNegativeFeedback()
    {
        var a1 = NegativeFeedbackSoundClip;
        var a2 = NegativeFeedbackListClip[Random.Range(0, 8)];
        StartCoroutine(playAudioSequentially(a1, a2));
        yield return StartCoroutine(playAudioSequentially(a1, a2));
        //PositiveFeedbackSource.clip = PositiveFeedbackListClip[Random.Range(0, 8)];
        //PositiveFeedbackSource.Play();
    }
    **/



    // 18.04.19 Für negative sound version: PlayNegativeFeedback() auskommentieren
    public float PlayNegativeFeedback()
    {
        NegativeFeedbackSource.clip = NegativeFeedbackListClip[Random.Range(0, 8)];
        NegativeFeedbackSource.Play();
        return NegativeFeedbackSource.clip.length;
    }
   

    public void PlayHelpAudio()
    {
        HelpAudioSource.clip = HelpAudioClip;
        HelpAudioSource.Play();
    }

    public void StopHelpAudio()
    {
        HelpAudioSource.clip = HelpAudioClip;
        HelpAudioSource.Stop();
    }

    //public AudioSource adSource;
    //public AudioClip[] HelpArray;

    public IEnumerator playAudioSequentially(AudioClip a1, AudioClip a2)
    {
        var tmpList = new List<AudioClip> {a1, a2};
        foreach (var clip in tmpList)
        {
            // 2.Assign current AudioClip to audiosource
            PositiveFeedbackSource.Stop();
            PositiveFeedbackSource.clip = clip;

            //3.Play Audio
            PositiveFeedbackSource.Play();

            //4.Wait for it to finish playing
            yield return new WaitForSeconds(PositiveFeedbackSource.clip.length);
        }
    }
}