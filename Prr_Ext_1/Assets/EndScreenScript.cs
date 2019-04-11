using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    private void Start()
    {             
        Debug.Log("Final Score: " + Controller.Instance.Sc);
    }



    
}
