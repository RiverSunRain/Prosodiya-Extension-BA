using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideProgressBarFillerScript : MonoBehaviour
{
    public float FillerHeight
    {
        get { return _fillerHeight; }
        set
        {
            _fillerHeight = value;
            GetComponent<RectTransform>().offsetMin = new Vector2(0, 0);
            GetComponent<RectTransform>().offsetMax = new Vector2(0, -_fillerHeight);
        }
    }

    private float _fillerHeight;

    public void UpdateFiller(bool success, bool lastUpdate = false)
    {
        var color = success ? SideProgressBarScript.Instance.SuccessColor : SideProgressBarScript.Instance.FailColor;
        GetComponent<Image>().color = color;

        //animate celebrate 
        if (lastUpdate)
        {
            //animation für das letzte update in der sideprogressbar. Großes feuerwerk/explosion nach oben
        }
        else
        {
        }
        LeanTween.value(gameObject, _fillerHeight, 0, 0.4f)
            .setOnUpdate(value => { GetComponent<RectTransform>().offsetMax = new Vector2(0, -value); }).setEase(LeanTweenType.easeInOutSine);
    }
}