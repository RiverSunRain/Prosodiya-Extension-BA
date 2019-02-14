using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controller : MonoBehaviourSingleton<Controller>
{
    public int MaxClicks = 4;

    public GameObject CloudWrapper;
    public GameObject CloudPrefabs;

    List<List<Word>> mainList = new List<List<Word>>();

    public List<Word> WordList;
    public List<Word> WordList2;
    public List<Word> WordList3;
    public List<Word> WordList4;
    public List<Word> WordList5;
    public List<Word> WordList6;
    public List<Word> WordList7;
    public List<Word> WordList8;
    public List<Word> WordList9;
    public List<Word> WordList10;

    public List<Vector2> AllowedPositions;

    //referenz zum audio
    public start_audio_script sas;

    void Start()
    {
        mainList.Add(WordList);
        mainList.Add(WordList2);
        mainList.Add(WordList3);
        mainList.Add(WordList4);
        mainList.Add(WordList5);
        mainList.Add(WordList6);
        mainList.Add(WordList7);
        mainList.Add(WordList8);
        mainList.Add(WordList9);
        mainList.Add(WordList10);

        PrepareScene();
    }

    public void PrepareScene()
    {
        
        /*
        for (var i = 0; i < 10; i++)
        {
            PrepareClouds(mainList[i]); // Interation through al sublist, doesn't work :(
        }
        **/

        PrepareClouds(mainList[0]);

        StartGame();
        
    }

    public void StartGame()
    {
        sas.PlayAudioClip();
    }

    public void PrepareClouds(List<Word> subList)
    {
        int i = 0;

        foreach (var word in subList)
        {
            //word erstellen
            var x = Instantiate(CloudPrefabs, CloudWrapper.transform);
            x.GetComponentInChildren<Text>().text = word.WordString;
            x.GetComponent<tw_button_script>().Word = word;
            //zufällig eine pos aus der liste entnehmen
            //var randomPos = AllowedPositions[Random.Range(0, AllowedPositions.Count)];
            var randomPos = AllowedPositions[i];
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

    public void CloudWasClicked(Word word)
    {
        Debug.Log(word.WordString);
    }
}