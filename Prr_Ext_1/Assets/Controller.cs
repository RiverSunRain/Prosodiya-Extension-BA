using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviourSingleton<Controller>
{
    public int MaxClicks = 4;

    public GameObject CloudWrapper;
    public GameObject CloudPrefabs;
    public List<Word> WordList;
    public List<Vector2> AllowedPositions;

    //referenz zum audio
    public start_audio_script sas;

    void Start()
    {
        PrepareScene();
    }

    public void PrepareScene()
    {
        PrepareClouds();
        StartGame();
    }

    public void StartGame()
    {
        sas.PlayAudioClip();
    }

    public void PrepareClouds()
    {
        foreach (var word in WordList)
        {
            //word erstellen
            var x = Instantiate(CloudPrefabs, CloudWrapper.transform);
            x.GetComponentInChildren<Text>().text = word.WordString;
            x.GetComponent<tw_button_script>().Word = word;
            //zufällig eine pos aus der liste entnehmen
            var randomPos = AllowedPositions[Random.Range(0, AllowedPositions.Count)];
            x.GetComponent<RectTransform>().anchoredPosition = randomPos;
            AllowedPositions.Remove(randomPos);
        }
    }
    
    public void CleanupScene()
    {
        foreach (Transform child in CloudWrapper.transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void ChangeScene()
    {
        var SceneNumber = 2;
        if (SceneNumber == 2)
        {
            SceneManager.LoadScene("Scene_2");
        }
    }

    public void CloudWasClicked(string wordText)
    {
        Debug.Log(wordText);
    }
}