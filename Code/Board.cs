using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update

    public int width;
    public int height;
    public GameObject tilePrefab;
    private Background[,] tiles;
    public GameObject[] symbols;
    public GameObject[,] allSymbols;
    public ScoreManager scoreManager;


    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    	tiles = new Background[width, height];
        allSymbols = new GameObject[width, height];
    	setUp();

        
    }

    private void setUp(){
    	for(int i = 0;  i < width; i++){
    		for(int j = 0; j < height ; j++){
    			Vector2 temp = new Vector2(i, j);
    			GameObject tile = Instantiate(tilePrefab, temp, Quaternion.identity) as GameObject;
    			tile.transform.parent = this.transform;
    			tile.name = "( " + i + ", " + j + " )";
                int symToUse = Random.Range(0, symbols.Length);
                GameObject sym = Instantiate(symbols[symToUse]  , temp, Quaternion.identity);
                sym.transform.parent = this.transform;
                sym.name = "( " + i + ", " + j + " )";
                allSymbols[i,j] = sym;
    		}
    	}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
