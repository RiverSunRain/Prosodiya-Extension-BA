using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class CharacterCreator : MonoBehaviourSingleton<CharacterCreator>
{

    public InputField AgeInput;
    public InputField GenderInput;
    public InputField HandednessInput;
    public InputField SubjectNumberInput;

    public string Age { get; set; }
    public string Gender { get; set; }
    public string Handedness { get; set; }
    public string SubjectNumber { get; set; }

    public void OnSubmit() {

        Age = AgeInput.text;
        Gender = GenderInput.text;
        Handedness = HandednessInput.text;
        SubjectNumber = SubjectNumberInput.text;
        
        DontDestroyOnLoad(this.gameObject);

        SceneManager.LoadScene("Scene_1");
    }
}
