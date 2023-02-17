using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Symbol : MonoBehaviour
{
	public int column;
	public int row;
	private Board board;
	private GameObject otherSymbol;
	private Vector2 firstTouchPosition;
	private Vector2 finalTouchPosition;
	private Vector2 temp;
	public float swipeAngle = 0;
	public int targetX;
	public int targetY;
	public bool isMatched = false;
	public Sprite Tick;
	public float swipeThreshold = .2f;
    public bool increasedScore = false;


    // Start is called before the first frame update
    void Start()
    {
    	board = FindObjectOfType<Board>();
    	targetX = (int)transform.position.x;
    	targetY = (int)transform.position.y;
    	row = targetY;
    	column = targetX;
        
    }

    // Update is called once per frame
    void Update()
    {
    	Match();

    	if(isMatched){
    		this.gameObject.GetComponent<SpriteRenderer>().sprite = Tick;
    	}

    	targetX = column;
    	targetY = row;
        
       if(Mathf.Abs(targetX - transform.position.x) > .1){
        	temp = new Vector2(targetX, transform.position.y);
        	transform.position = Vector2.Lerp(transform.position, temp, .4f);
        } else {
        	temp = new Vector2(targetX, transform.position.y);
        	transform.position = temp;
        	board.allSymbols[column, row] = this.gameObject;
        }

        if(Mathf.Abs(targetY - transform.position.y) > .1){
        	temp = new Vector2(transform.position.x, targetY);
        	transform.position = Vector2.Lerp(transform.position, temp, .4f);
        } else {
        	temp = new Vector2(transform.position.x, targetY);
        	transform.position = temp;
        	board.allSymbols[column, row] = this.gameObject;
        }


    }

    private void OnMouseDown(){
    	firstTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	//Debug.Log(firstTouchPosition);
    }

    private void OnMouseUp(){
    	finalTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	CalculateAngle();
    }

    void CalculateAngle()
    {
    	if(Mathf.Abs(finalTouchPosition.y - firstTouchPosition.y) > swipeThreshold || Mathf.Abs(finalTouchPosition.x - firstTouchPosition.x) > swipeThreshold){
    		swipeAngle = Mathf.Atan2(finalTouchPosition.y - firstTouchPosition.y, finalTouchPosition.x - firstTouchPosition.x);
        	swipeAngle *= Mathf.Rad2Deg;
        	if (swipeAngle > -45 && swipeAngle <= 45 && column < board.width)//Right Swipe
        	{
        	    MovePieces(1, 0);//Switch with piece:(x+1,y+0)
        	}
        	else if (swipeAngle > 45 && swipeAngle <= 135 && row < board.height)//Up Swipe
        	{
        	    MovePieces(0, 1);//See previous
        	}
        	else if (swipeAngle < -45 && swipeAngle >= -135 && row > 1)//Down Swipe
        	{
        	    MovePieces(0, -1);
        	}
        	else if (swipeAngle > 135 || swipeAngle <= 135 && column > 1)//Left Swipe
        	{
            	MovePieces(-1, 0);
        	}
    	}
        
    }
    
    void MovePieces(int columnMove, int rowMove)
    {
        otherSymbol = board.allSymbols[column + columnMove, row + rowMove];//Find the piece in that direction
        if(!isMatched && !otherSymbol.GetComponent<Symbol>().isMatched){
	        otherSymbol.GetComponent<Symbol>().column -= columnMove;
	        otherSymbol.GetComponent<Symbol>().row -= rowMove;
	        column += columnMove;
	        row += rowMove;
        }
    }

    void Match(){
    	bool match = true;
    	for(int c = 0 ; c < board.width ; c++){
    		GameObject currentSym = board.allSymbols[c, row];
    		if(currentSym.tag != this.gameObject.tag){
    			match = false;
    			break;
    		}
    	}

    	if(match){
            if(this.gameObject.tag == "Blue" && !increasedScore){
                board.scoreManager.increaseScore(200);
                increasedScore = true;

            } else if (this.gameObject.tag == "Green" && !increasedScore){
                board.scoreManager.increaseScore(150);
                increasedScore = true;

            } else if (this.gameObject.tag == "Red" && !increasedScore){
                board.scoreManager.increaseScore(100);
                increasedScore = true;

            } else if (this.gameObject.tag == "Yellow" && !increasedScore){
                board.scoreManager.increaseScore(250);
                increasedScore = true;

            } 
    		for(int c = 0 ; c < board.width; c++){
    			GameObject currentSym = board.allSymbols[c, row];
    			currentSym.GetComponent<Symbol>().isMatched = true;
    		}
    		
    	}
    }
}
