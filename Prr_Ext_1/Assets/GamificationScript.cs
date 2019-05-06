using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamificationScript : MonoBehaviourSingleton<GamificationScript>
{
    public SpriteRenderer yellowBlob;

    public void deactivateGamification(string set)
    {
        if (set == "Off")
        {
            yellowBlob.enabled = false;
        }
    }
}
