using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tw_button_script : MonoBehaviour
{
    public Word Word;

    public void CloudClicked()
    {
        Destroy(gameObject);
        Controller.Instance.CloudWasClicked(Word.WordString);
    }


}
