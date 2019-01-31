using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tw_button_script : MonoBehaviour
{
    public int SceneNumber;
    public GameObject Obj;

    public void OnMouseDown()
    {
        SceneNumber = 2;
        Destroy(gameObject);
        if (SceneNumber == 2)
        {
            SceneManager.LoadScene("Scene_2");
        }
    }


}
