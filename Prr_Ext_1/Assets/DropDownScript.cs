using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropDownScript : MonoBehaviour
{

    List<string> names = new List<string> { "Select Subtasks:", "4 Subtasks", "6 Subtasks", "8 Subtasks", "10 Subtasks" };

    public Dropdown dropDown;
    public Text selectedText;

    public void DropDownIndexChange(int index) {
        selectedText.text = names[index];
    }


	void Start () {
        
        PopulateList();
	}

    void PopulateList() {
        dropDown.AddOptions(names);
    }
}
