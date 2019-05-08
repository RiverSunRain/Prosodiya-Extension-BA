using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviourSingleton<ScoreScript> {

    public static int ScoreValue = 0;
    Text ScoreText;

	// Use this for initialization
	void Start () {
        ScoreText = GetComponent<Text>();
	}
	

	// Update is called once per frame
	void Update () {
        
        ScoreText.text = ScoreValue.ToString();
	}

    public void Setback() {
        Debug.Log(ScoreText.text);
        ScoreValue = 0;
        ScoreText.text = ScoreValue.ToString();
    }
}
