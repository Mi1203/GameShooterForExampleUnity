using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ChangeScene : MonoBehaviour {

	// Use this for initialization
    public void LoadScene(string LevelLoad) 
    {
        SceneManager.LoadScene(LevelLoad);
        
        //Application.LoadLevel(LevelLoad);
    }
	
	// Update is called once per frame
	public void Quit () {
		Application.Quit();
	}
}
