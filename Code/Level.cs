using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu (fileName = "World" , menuName = "Level")]
public class Level : ScriptableObject
{

	public int levelNumber;

	public int width;
	public int height;

	public int moveCount;

	public GameObject[] symbols;


}
