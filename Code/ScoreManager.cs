using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
	public TMP_Text scoreText;
	public int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    	scoreText.text = "" + score;
        
    }

    public void increaseScore(int amount){

    	score += amount;

    }
}
