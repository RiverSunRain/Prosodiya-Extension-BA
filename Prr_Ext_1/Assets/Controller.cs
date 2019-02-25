using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Controller : MonoBehaviourSingleton<Controller>
{
    public int MaxClicks = 3;
    private int _clicks = 0;

    public GameObject CloudWrapper;
    public GameObject CloudPrefabs;
    bool JumpTrigger = false;

    //bene: wordlist items werden im inspector referenziert
    //neues Item erstellt, das du in deinen Assets einfach hinzufügen kannst, habe 2 bsp Wortlisten erstellt, siehe Inspector beim Controller
    public List<WordListItem> MainWordList = new List<WordListItem>();

    //bene: counter für den index zur aktuellen wordliste
    private int _listCounter = 0;

    /*
    public List<WordListItem> WordList;
    public List<Word> WordList2;
    public List<Word> WordList3;
    public List<Word> WordList4;
    public List<Word> WordList5;
    public List<Word> WordList6;
    public List<Word> WordList7;
    public List<Word> WordList8;
    public List<Word> WordList9;
    public List<Word> WordList10;
    **/

    public List<Vector2> AllowedPositions;

    //referenz zum audio
    public start_audio_script sas;

    
    void Start()
    {
        /*
        MainWordList.Add(WordList);
        MainWordList.Add(WordList2);
        MainWordList.Add(WordList3);
        MainWordList.Add(WordList4);
        MainWordList.Add(WordList5);
        MainWordList.Add(WordList6);
        MainWordList.Add(WordList7);
        MainWordList.Add(WordList8);
        MainWordList.Add(WordList9);
        MainWordList.Add(WordList10);
        **/
        
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

        //liste mit dem aktuellen counter übergeben
        sas.PlayAudioClip();
        PrepareClouds(MainWordList[_listCounter]);
        
        StartGame();
    }

    public void StartGame()
    {
        
    }

    public void PrepareClouds(WordListItem subList)
    {
        int i = 0;

        foreach (var word in subList.WordList)
        {
            //word erstellen
            var x = Instantiate(CloudPrefabs, CloudWrapper.transform);
            x.GetComponentInChildren<Text>().text = word.WordString;
            x.GetComponent<tw_button_script>().Word = word;
            //zufällig eine pos aus der liste entnehmen
            //var randomPos = AllowedPositions[Random.Range(0, AllowedPositions.Count)];
            var randomPos = AllowedPositions[i];
            x.GetComponent<RectTransform>().anchoredPosition = randomPos;
            //AllowedPositions.Remove(randomPos); <--- eher unsauber die liste zu verändern, da sonst der index durcheinander kommt
            //bene: einfach i erhöhen hier, liste muss nicht geleert werden
            i++;
        }
    }

    public void CleanupScene()
    {
        //bene: counter erhöhen für den nächsten durchgang
        _listCounter++;
        //bene: click counter zurücksetzen
        _clicks = 0;

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
        //Bene: anzahl der clicks erhöhen und schaun ob das limit erreicht ist
        _clicks++;
        if (_clicks == MaxClicks || word.Distractor == false)
        {
            AnimationScript.Instance.s = true;
            AnimationScript._instance.Update();
            //bene: wenn ja, dann szene cleanen und nächste preparen
            Debug.Log("nächster Durchgang wird gestartet");
            //in der cleanup funktion wird der counter für die mainliste erhöht, damit das nächste element in der liste prepared werden kann
            CleanupScene();
            PrepareScene();
        }
    }
}