using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main_Menu_Manager : MonoBehaviour {

    public string SceneToLoad;


    public void playGame()
    {
        SceneManager.LoadScene(SceneToLoad);

    }

    public void quitGame()
    {
        Application.Quit();

    }
}




