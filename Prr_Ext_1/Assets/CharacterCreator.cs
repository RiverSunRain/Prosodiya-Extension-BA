using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class CharacterCreator : MonoBehaviour {

    public InputField AgeInput;
    public InputField GenderInput;
    public InputField HandednessInput;
    public InputField SubjectNumberInput;

    private string age;
    private string gender;
    private string handedness;
    private string subjectNumber;

    public void OnSubmit() {

        age = AgeInput.text;
        gender = GenderInput.text;
        handedness = HandednessInput.text;
        subjectNumber = SubjectNumberInput.text;

        Debug.Log("Age: " + age);
        Debug.Log("Gender: " + gender);
        Debug.Log("Handedness: " + handedness);
        Debug.Log("Subject number: " + subjectNumber);

        SceneManager.LoadScene("Scene_1");
    }
}
