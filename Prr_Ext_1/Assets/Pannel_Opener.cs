using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pannel_Opener : MonoBehaviour
{
    public GameObject Panel;
    public start_audio_script sas;

    public void openPanel() {

        if (Panel != null)
        {
            sas.PlayHelpAudio();
            Panel.SetActive(true);
        }
       
    }
}
