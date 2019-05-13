using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData {

    public string age;
    public string gender;
    public string handness;
    public string subjectNumber;

    public PlayerData(CharacterCreator characterCreator) {

        age = characterCreator.Age;
        gender = characterCreator.Gender;
        handness = characterCreator.Handedness;
        subjectNumber = characterCreator.SubjectNumber;
    } 
}
