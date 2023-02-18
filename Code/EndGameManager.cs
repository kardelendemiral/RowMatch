using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGameManager : MonoBehaviour
{
	public TMP_Text moveCountText;
	public TMP_Text levelCountText;
	public int currentMoveCount;
	private Board board;
    // Start is called before the first frame update
    void Start()
    {
    	board = FindObjectOfType<Board>();
        moveCountText.text = "" + currentMoveCount;
        if(board != null){
        	currentMoveCount = board.world.levels[board.level].moveCount;
        	levelCountText.text = "" + board.world.levels[board.level].levelNumber;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveCountText.text = "" + currentMoveCount;
    }

    public void DecreaseMoveCount(){
    	currentMoveCount -= 1;
    	moveCountText.text = "" + currentMoveCount;
    	
    	if(currentMoveCount == 0){
    		board.currentState = GameState.lose;
    		EndGame();
    	}
    	
    }

    void EndGame(){
    	Debug.Log("end game");
    	SceneManager.LoadScene("LevelSelect", LoadSceneMode.Single);

    }

}
