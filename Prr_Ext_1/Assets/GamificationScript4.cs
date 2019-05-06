using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamificationScript4 : MonoBehaviourSingleton<GamificationScript4> {

    public GameObject sideprogressbar;

    public void destroySideprogressbar(string s) {
        if (s == "Off" ) {
            Destroy(sideprogressbar);
        }
    }
}
