using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class SideProgressBarScript : MonoBehaviourSingleton<SideProgressBarScript>
{
    public GameObject FillerPrefab;
    public GameObject SeparatorPrefab;
    public GameObject SeparatorWrapper;
    public Color32 SuccessColor;
    public Color32 FailColor;

    private int _totalSubTaskCount = 1;
    private int _subTaskCompleted = 0;
    private List<GameObject> _separatorList = new List<GameObject>();

    private List<GameObject> _fillerList
    {
        get { return (from Transform child in gameObject.transform select child.gameObject).ToList(); }
    }

    private float _fillerHeight
    {
        get
        {
            //höhe minus den paddings oben und unten
            var thisHeight = transform.parent.GetComponent<RectTransform>().sizeDelta.y -
                             (-GetComponent<RectTransform>().offsetMax.y + GetComponent<RectTransform>().offsetMin.y);

            var numberOfSpaces = _totalSubTaskCount - 1;
            var spacing = GetComponent<VerticalLayoutGroup>().spacing;
            return (thisHeight / _totalSubTaskCount) - (numberOfSpaces * spacing) / _totalSubTaskCount;
        }
    }


    protected override void Start()
    {
        base.Start();
        //PrepareSideProgressBar(8);
    }

    #region external Calls

    public void PrepareSideProgressBar(int numberOfSubTasks)
    {
        _totalSubTaskCount = numberOfSubTasks;
        for (int i = 0; i < _totalSubTaskCount; i++)
        {
            var filler = Instantiate(FillerPrefab, gameObject.transform) as GameObject;
            filler.GetComponentInChildren<SideProgressBarFillerScript>().FillerHeight = _fillerHeight;
            filler.name = (_totalSubTaskCount - i).ToString();

            //add separators, skip last separator
            if (i + 1 != _totalSubTaskCount)
            {
                _separatorList.Add(Instantiate(SeparatorPrefab, SeparatorWrapper.transform));
            }
        }
    }

    public GameObject UpdateSideProgressBar(bool success)
    {
        GameObject fillerGoToUpdate = null;
        if (_subTaskCompleted < _totalSubTaskCount)
        {
            // update it
            _subTaskCompleted++;

            //get filler to update
            fillerGoToUpdate =
                (from filler in _fillerList where filler.name.Equals(_subTaskCompleted.ToString()) select filler)
                .FirstOrDefault();
            var fillerToUpdate = fillerGoToUpdate.GetComponentInChildren<SideProgressBarFillerScript>();

            if (_subTaskCompleted + 1 < _totalSubTaskCount)
            {
                // normal animation
                fillerToUpdate.UpdateFiller(success);
            }
            else
            {
                //last update bigger animation
                // normal animation
                fillerToUpdate.UpdateFiller(success, true);
            }
        }
        else
        {
            // End it
        }
        return fillerGoToUpdate;
    }

    public void ResetSideProgressBar()
    {
        _totalSubTaskCount = 1;
        _subTaskCompleted = 0;
        foreach (var filler in _fillerList)
        {
            Destroy(filler);
        }
        _fillerList.Clear();

        //delete separators
        foreach (var child in _separatorList)
        {
            GameObject.Destroy(child);
        }
        _separatorList.Clear();
    }

    #endregion
}