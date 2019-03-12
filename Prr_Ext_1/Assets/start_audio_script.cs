using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_audio_script : MonoBehaviour
{

   

    public AudioClip MusicClip;

    public AudioSource MusicSource;

    public AudioClip PositiveFeedbackSoundClip;
    public AudioSource PositiveFeedbackSoundSource;

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

    public void PlayPositiveFeedbackSound() {

        PositiveFeedbackSoundSource.clip = PositiveFeedbackSoundClip;
        PositiveFeedbackSoundSource.Play();
    }

    public void PlayPositiveFeedback()
    {
        PositiveFeedbackSource.clip = PositiveFeedbackListClip[Random.Range(0,8)];
        PositiveFeedbackSource.Play();
    }

    public void PlayNegativeFeedback()
    {
        NegativeFeedbackSource.clip = NegativeFeedbackListClip[Random.Range(0, 8)];
        NegativeFeedbackSource.Play();
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

    /*
    public AudioSource adSource;
    public AudioClip[] HelpArray;
    
    public IEnumerator playAudioSequentially()
    {
        HelpArray[0] = PositiveFeedbackSoundClip;
        HelpArray[1] = PositiveFeedbackListClip[0];

        yield return null;

        //1.Loop through each AudioClip
        for (int i = 0; i < 2; i++)
        {
            //2.Assign current AudioClip to audiosource
            adSource.clip = HelpArray[i];

            //3.Play Audio
            adSource.Play();

            //4.Wait for it to finish playing
            while (adSource.isPlaying)
            {
                yield return null;
            }

            //5. Go back to #2 and play the next audio in the adClips array
        }
    }
    **/

}

