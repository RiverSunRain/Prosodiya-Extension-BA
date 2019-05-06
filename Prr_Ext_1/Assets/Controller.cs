using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Prosodiya;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Controller : MonoBehaviourSingleton<Controller>
{
    public int MaxClicks = 3;
    private int _clicks = 0;

    private bool Hit = true;
    private bool isLast = false;

    public Text roundnumberText;
    int i = 1;

    public GameObject Sc;

    public GameObject CloudWrapper;
    public GameObject CloudPrefabs;
    bool JumpTrigger = false;

    //bene: wordlist items werden im inspector referenziert
    //neues Item erstellt, das du in deinen Assets einfach hinzufügen kannst, habe 2 bsp Wortlisten erstellt, siehe Inspector beim Controller

    // Wordlists

    public List<WordListItem> MainWordList = new List<WordListItem>();

    public List<WordListItem> MainWordList4off = new List<WordListItem>();

    public List<WordListItem> MainWordListSix = new List<WordListItem>();

    public List<WordListItem> MainWordListEight = new List<WordListItem>();

    public List<WordListItem> MainWordListTen = new List<WordListItem>();

    public WordListItem CurrentWordListItem;

    private int _maxAllowedClicks
    {
        get { return CurrentWordListItem.WordList.Count(x => x.Distractor == false); }
    }

    //bene: counter für den index zur aktuellen wordliste
    public int _listCounter = 0;

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









































    //public static DropDownScript dropDownScript;



    //FINAL GAME STRUCTURE

    void Start()
    {
        Debug.Log("Start() ##");
        GamificationScript.Instance.deactivateGamification(CharacterCreator.Instance.Gamification);
        GamificationScript1.Instance.deactivateGamification(CharacterCreator.Instance.Gamification);
        GamificationScript2.Instance.deactivateGamification(CharacterCreator.Instance.Gamification);
        GamificationScript3.Instance.deactivateGamification(CharacterCreator.Instance.Gamification);
        GamificationScript4.Instance.destroySideprogressbar(CharacterCreator.Instance.Gamification);
        GamificationScript5.Instance.destroySideprogressbar(CharacterCreator.Instance.Gamification);
        RoundnumberScript.Instance.destroyRoundnumber(CharacterCreator.Instance.Gamification);
        RoundScript.Instance.destroyRound(CharacterCreator.Instance.Gamification);
        PrepareScene();   
    }

    public void PrepareScene()
    {
        Debug.Log("PrepareScene() ##");
        StartGame();        
        //prepare scene related stuff
        
    }

    public void StartGame()
    {
        Debug.Log("StartGame() ##");
        foreach (var btn in FindObjectsOfType<Button>())
        {
            btn.interactable = true;
        }
        //placeholder
        //TopProgressBar.Instance.UpdateProgress();

        PrepareTask();
    }

    public void PrepareTask()
    {
        Debug.Log("PrepareTask() ##");
        Hit = true;
        //prepare top pb
        if (CharacterCreator.Instance.Gamification == "On") {
            TopProgressBar.Instance.Prepare(10);
        }

        /*
        if (CharacterCreator.Instance.Gamification == "Off")
        {
            i++;
            roundnumberText.text = i.ToString();
        }
       **/
        if (CharacterCreator.Instance.Gamification == "Off")
        {
            i = RoundnumberScript.Instance.updateRound(i);
        }




        //prepare clouds
        //CurrentWordListItem = MainWordListTen[_listCounter];

        if (CharacterCreator.Instance.Gamification == "On")
        {


            if (CharacterCreator.Instance.NumberOfClouds == "4")
            {
                CurrentWordListItem = MainWordList[_listCounter];
            }
            else if (CharacterCreator.Instance.NumberOfClouds == "6")
            {
                CurrentWordListItem = MainWordListSix[_listCounter];
            }
            else if (CharacterCreator.Instance.NumberOfClouds == "8")
            {
                CurrentWordListItem = MainWordListEight[_listCounter];
            }
            else if (CharacterCreator.Instance.NumberOfClouds == "10")
            {
                CurrentWordListItem = MainWordListTen[_listCounter];
            }
            else
            {
                //Default, 4 Clouds
                CurrentWordListItem = MainWordList[_listCounter];
            }





        }
        else if (CharacterCreator.Instance.Gamification == "Off") {

            if (CharacterCreator.Instance.NumberOfClouds == "4")
            {
                CurrentWordListItem = MainWordList4off[_listCounter];
            }
            else if (CharacterCreator.Instance.NumberOfClouds == "6")
            {
                CurrentWordListItem = MainWordListSix[_listCounter];
            }
            else if (CharacterCreator.Instance.NumberOfClouds == "8")
            {
                CurrentWordListItem = MainWordListEight[_listCounter];
            }
            else if (CharacterCreator.Instance.NumberOfClouds == "10")
            {
                CurrentWordListItem = MainWordListTen[_listCounter];
            }
            else
            {
                //Default, 4 Clouds
                CurrentWordListItem = MainWordList4off[_listCounter];
            }

        }

        









      












        //CurrentWordListItem = selectList(CharacterCreator.Instance.NumberOfClouds)[_listCounter];
        PrepareClouds(CurrentWordListItem);
        StartTask();
    }

    public void StartTask()
    {
        Debug.Log("StartTask() ##");
        if (CharacterCreator.Instance.Gamification == "On") {
            SideProgressBarScript.Instance.PrepareSideProgressBar(_maxAllowedClicks);
        }
        PrepareSubTask();
    }

    public void PrepareSubTask()
    {
        Debug.Log("PrepareSubTask() ##");

        if(CharacterCreator.Instance.Gamification == "On") {
            ScoreStarScript.Instance.b = false;
            ScoreStarScript.Instance.Flashing();
        }
             
        foreach (var btn in FindObjectsOfType<Button>())
        {
            btn.interactable = true;
        }

        //prepare side pb

        
        StartSubtask();
    }

    
    public void StartSubtask()
    {
        Debug.Log("StartSubTask() ##");
        
        //jump to finishsubtask, wenn bedinung dafür erfüllt (es wurde geklickt)
        //bleibt vermutlich leer, da finish subtask von cloudwasclick gecalled wird
        //FinishSubTask(); // DANGEROUS, INFINITE LOOP!
    }
    

    public void FinishSubTask()
    {
        Debug.Log("FinishSubTask() ##");
        //update side pb
        
        //animations here

        CleanupSubTask();
    }

    public void FinishTask()
    {
        Debug.Log("FinishTask() ##");
        //update top pb
        //TopProgressBar.Instance.UpdateProgress();
        CleanupTask();
    }

    public void FinishGame()
    {
        Debug.Log("FinishGame() ##");
        CleanupScene();
    }

    public void CleanupSubTask()
    {
        Debug.Log("CleanUpSubTask() ##");

        
        //if (_clicks == 3) { SideProgressBarScript.Instance.ResetSideProgressBar(); }
        //###abbruchbedinung subtasks
        //abfrage ob letzte subtask (click abfrage)
        //wenn ja, cleanup Task
        if (_clicks >= _maxAllowedClicks)
        {
            //SideProgressBarScript.Instance.ResetSideProgressBar();
            FinishTask();
        }
        //wenn nicht, dann prepare subtask
        else
        {
            PrepareSubTask();
        }
    }

    public void CleanupTask()
    {
        Debug.Log("CleanUpTask() ##");

        if (CharacterCreator.Instance.Gamification == "On") {
            SideProgressBarScript.Instance.ResetSideProgressBar();
        }
        
        //bene: counter erhöhen für den nächsten durchgang
        _listCounter++;
        //bene: click counter zurücksetzen
        _clicks = 0;

        foreach (Transform child in CloudWrapper.transform)
        {
            Destroy(child.gameObject);
        }



        //###abbruchbedinung tasks
        //listcount max erreicht?
        //ja
        if (_listCounter == 10) {
            FinishGame();
        }
        else
        {
            PrepareTask();
        }
        
        //nein
        
    }

    public void CleanupScene()
    {
        Debug.Log("CleanupScene() ##");
        //    Szenenwechsel
        SceneManager.LoadScene("End_Screen");
    }



    // END FINAL GAME STRUCTURE



















































































    /*
    void Start()
    {
        
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
        
        
        PrepareScene();

        //prepare side pb
        //SideProgressBarScript.Instance.PrepareSideProgressBar(MaxClicks);

        //prepare top pb
        //TopProgressBar.Instance.Prepare(10);
    }
    **/
    /*
    public void PrepareScene()
    {
        Debug.Log(_listCounter);


        
        //for (var i = 0; i < 10; i++)
        //{
          //  PrepareClouds(mainList[i]); // Interation through al sublist, doesn't work :(
        //}
        

        //liste mit dem aktuellen counter übergeben
        //sas.PlayAudioClip();


        if (_listCounter < 10)
        {
            if (_listCounter == 9) {
                isLast = true;
            }
            CurrentWordListItem = MainWordList[_listCounter];
            PrepareClouds(CurrentWordListItem);
            StartGame();
        }
        //else
       //{

            //Sc.text = ScoreScript.ScoreValue.ToString();
            

            //DontDestroyOnLoad(Sc);
            //SceneManager.LoadScene("End_Screen");
        //}
    }
    **/

    /*
public void StartGame()
{
    Debug.Log("1 ##");
    foreach (var btn in FindObjectsOfType<Button>())
    {
        btn.interactable = true;
    }

    //placeholder
    TopProgressBar.Instance.UpdateProgress();
}
**/
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

        //Tests if data from Input Scene have been saved
        
        /*
        Debug.Log("Age: " + CharacterCreator._instance.Age);
        Debug.Log("Gender: " + CharacterCreator._instance.Gender);
        Debug.Log("Handedness: " + CharacterCreator._instance.Handedness);
        Debug.Log("Subject number: " + CharacterCreator._instance.SubjectNumber);
        **/
    }

    /*
    public void CleanupScene()
    {
        Debug.Log("3 ##");
        //bene: counter erhöhen für den nächsten durchgang
        _listCounter++;
        //bene: click counter zurücksetzen
        _clicks = 0;


        foreach (Transform child in CloudWrapper.transform)
        {
            Destroy(child.gameObject);
        }
    }
    **/
    /*
    public void ChangeScene()
    {
        var SceneNumber = 2;
        if (SceneNumber == 2)
        {
            SceneManager.LoadScene("Scene_2");
        }
    }
    **/

    public IEnumerator CloudWasClicked(Word word, GameObject cloudGo)
    {
        /*
        *cloud clicked
            interactable = false
        wenn distr

        if is last
            w8 feedback pos +animation blob

        cleanup + (prep next)
        else
        w8 animation blob
            animation dissolve + destroy
        else
        w8 feedback pos + animation blob
            w8 animation cloud to progressbar

        cleanup + (prepare next)
        */


        float animTime;
        //Bene: anzahl der clicks erhöhen und schaun ob das limit erreicht ist
        _clicks++;
        Debug.Log("XXXXXXXXXXXXX clicks: " + _clicks);

        if (word.Distractor == false)
        {
            Debug.Log("CloudWasClicked() tw");
            //pb

            //GameObject upd = SideProgressBarScript.Instance.UpdateSideProgressBar(true);

            if (CharacterCreator.Instance.Gamification == "On") {
                var go = SideProgressBarScript.Instance.UpdateSideProgressBar(true);
                //Animation Cloud zu filler - move
                LeanTween.move(cloudGo, go.transform.position, 1f);
                //scale it, make it smaller
                LeanTween.scale(cloudGo, Vector3.zero, 1f);
            }
            



            //sas.PlayPositiveFeedbackSound();
            //sas.playAudioSequentially();

            if (CharacterCreator.Instance.Gamification == "On") {
                ScoreStarScript.Instance.b = true;
                ScoreStarScript.Instance.StartFlashing();
            }
           
            AnimationScript.Instance.s = true;
            //wait for animation to finish
            AnimationScript.Instance.UpdateAnimation();

            foreach (var btn in FindObjectsOfType<Button>())
            {
                btn.interactable = false;
            }

            //Debug.Log("5 ##");
            yield return sas.PlayPositiveFeedback();
            //ScoreScript.ScoreValue += 10;
            setScore(Hit);
            
            //bene: wenn ja, dann szene cleanen und nächste preparen
            //Debug.Log("nächster Durchgang wird gestartet");

            //in der cleanup funktion wird der counter für die mainliste erhöht, damit das nächste element in der liste prepared werden kann

            //CleanupScene();
            //PrepareScene();
            //if (_clicks == 3) { SideProgressBarScript.Instance.ResetSideProgressBar(); }

            

            FinishSubTask();
            PrepareSubTask();

            //Debug.Log("2 ##");

           
        }
        else
        {

                Debug.Log("CloudWasClicked() dist");
                //animTime = sas.PlayNegativeFeedback();
                

            Hit = false;

            //GameObject upd = SideProgressBarScript.Instance.UpdateSideProgressBar(false);

            if (CharacterCreator.Instance.Gamification == "On") {
                var go = SideProgressBarScript.Instance.UpdateSideProgressBar(false);
                //Animation Cloud zu filler - move
                LeanTween.move(cloudGo, go.transform.position, 1f);
                //scale it, make it smaller
                LeanTween.scale(cloudGo, Vector3.zero, 1f);
            }
                

                

                AnimationScript.Instance.t = true;
                AnimationScript.Instance.UpdateAnimation();

                foreach (var btn in FindObjectsOfType<Button>())
                {
                    btn.interactable = false;
                }

                //yield return new WaitForSeconds(animTime); // 18.04.19 Für negative sound version: auskommentieren

                yield return sas.PlayNegativeFeedback(); // 18.04.19 Für negative sound version: einkommentieren


            //CleanupScene();
            //PrepareScene();
            //if (_clicks == 3) { SideProgressBarScript.Instance.ResetSideProgressBar(); }



            FinishSubTask();
            PrepareSubTask();


          
        }
        /*
        if (_listCounter == 10)
        {
            SceneManager.LoadScene("End_Screen");
        }
        **/
        
    }

    public int setScore(bool directHit) {
        if (directHit == true) {
            return ScoreScript.ScoreValue += 15;
        }
        else {
            Hit = true;
            return ScoreScript.ScoreValue += 10;
        }
    }



}