using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    private void Start()
    {
        if(Controller.Initialized) Destroy(FindObjectOfType<Controller>().gameObject);
        if(CharacterCreator.Initialized) Destroy(FindObjectOfType<CharacterCreator>().gameObject);
    } 
}
