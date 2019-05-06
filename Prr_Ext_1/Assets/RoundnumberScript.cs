using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RoundnumberScript : MonoBehaviourSingleton<RoundnumberScript>
{
    public GameObject roundnumber;
    public Text rn;
    

    public int updateRound(int i) {
        rn.text = i.ToString();
        i++;
        return i;
    }

    public void destroyRoundnumber(string s)
    {
        if (s == "On")
        {
            Destroy(roundnumber);
        }
    }
}
