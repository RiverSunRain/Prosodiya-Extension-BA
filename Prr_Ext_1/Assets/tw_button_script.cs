﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tw_button_script : MonoBehaviour {

    public void setText(string text) {
        Text txt = transform.Find("Text").GetComponent<Text>();
        txt.text = text;
    }
}
