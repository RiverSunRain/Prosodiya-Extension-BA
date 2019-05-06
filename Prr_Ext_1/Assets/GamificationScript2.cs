using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamificationScript2 : MonoBehaviourSingleton<GamificationScript2>
{
    public Image scoreStar;

    public void deactivateGamification(string set)
    {
        if (set == "Off")
        {
            scoreStar.enabled = false;
        }
    }
}
