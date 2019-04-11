using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tw_button_script : MonoBehaviour
{
    public Word Word;

    public void CloudClicked()
    {
        GetComponent<Button>().interactable = false;
        StartCoroutine(Controller.Instance.CloudWasClicked(Word, this.gameObject));
        StartCoroutine(DissolveAnimation());
    }

    IEnumerator DissolveAnimation()
    {
        yield return new WaitForSeconds(1f);
        //Destroy(gameObject);
    }

}
