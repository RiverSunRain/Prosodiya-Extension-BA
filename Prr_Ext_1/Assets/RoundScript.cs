using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RoundScript : MonoBehaviourSingleton<RoundScript>
{
    public GameObject round;

    public void destroyRound(string s)
    {
        if (s == "On")
        {
            Destroy(round);
        }
    }
}
