using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamificationScript5 : MonoBehaviourSingleton<GamificationScript5>
{

    public GameObject topprogressbar;

    public void destroySideprogressbar(string s)
    {
        if (s == "Off")
        {
            Destroy(topprogressbar);
        }
    }
}
