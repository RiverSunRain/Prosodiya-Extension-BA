using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GamificationScript1 : MonoBehaviourSingleton<GamificationScript1>
{
    public SpriteRenderer rock;

    public void deactivateGamification(string set)
    {
        if (set == "Off")
        {
            rock.enabled = false;
        }
    }
}
