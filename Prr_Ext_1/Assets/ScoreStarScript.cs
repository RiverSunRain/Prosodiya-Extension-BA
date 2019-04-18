using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreStarScript : MonoBehaviourSingleton<ScoreStarScript>
{
    Image image;
    public bool b = true;
    
    public void StartFlashing()
    {
        image = GetComponent<Image>();
        StartCoroutine(Flashing());
    }
    
    public IEnumerator Flashing()
    {
       while (b == true)
       {
            yield return new WaitForSeconds(0.25f);
            image.enabled = !image.enabled;
       }

        if (b == false) {
            image.enabled = true;
        }
    }
    /*
    public IEnumerator StopFlashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            image.enabled = !image.enabled;
        }
    }
    **/
}