using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start_button_script : MonoBehaviour {

    public GameObject Panel;
    public start_audio_script sas;

    public void closePanel() {

        sas.StopHelpAudio();
        Panel.SetActive(false);
    }
}
