using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamificationScript3 : MonoBehaviourSingleton<GamificationScript3>
{
    public Text score;

    public void deactivateGamification(string set)
    {
        if (set == "Off")
        {
            score.enabled = false;
        }
    }
}
