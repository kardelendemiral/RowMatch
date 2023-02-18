using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButton : MonoBehaviour
{

	public TMP_Text levelText;
	public int Level;
	public GameObject confirmPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ConfirmPanel(){
    	confirmPanel.SetActive(true);
    }
}
