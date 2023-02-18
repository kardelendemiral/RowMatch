using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadLevelSelect(){
    	SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);
    	//Debug.Log("LoadSceneA");
    }

    public void LoadLevel(){
    	SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
}
