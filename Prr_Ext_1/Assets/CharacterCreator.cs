using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class CharacterCreator : MonoBehaviour {

    public InputField SubjectNumberField;
    private string number;

    public void OnSubmit() {

        number = SubjectNumberField.text;
        Debug.Log("Subject number: " + number);
        SceneManager.LoadScene("Scene_1");
    }
}
