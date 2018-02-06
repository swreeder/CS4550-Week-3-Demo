using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManger : MonoBehaviour {

    // Use this for initialization

    //public Animator startButton;
    //public Animator quitButton;
    //public Animator settingsButton;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    //public void OpenSettings()
    //{
    //    settingsButton.SetBool("isHidden", false);
    //}


    public void StartGame()
    {
        PlayerController.gameOver = false;
        SceneManager.LoadScene("Level1");
    }


    public void QuitGame()
    {
        Application.Quit();
        //use this for preview mode
        //UnityEditor.EditorApplication.isPlaying = false;
    }
}
