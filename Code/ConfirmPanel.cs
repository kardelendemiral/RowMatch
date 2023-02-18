using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ConfirmPanel : MonoBehaviour
{
	public string levelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Cancel(){
    	this.gameObject.SetActive(false);
    }

    private void Play(){
    	SceneManager.LoadScene(levelToLoad);

    }
}
