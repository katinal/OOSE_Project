﻿using UnityEngine;
using System.Collections;

public class BombBag : MonoBehaviour {
	public Transform bomb;
// object atributes 

	/// <summary>
	/// The bombplaced. tells how many not exploded bombs the player have placed in the game
	/// </summary>
	private int bombsPlaced;

	private int maxBombs;

	private int explodeRange;

	private LevelGenerator level;
	//methods

	// Use this for initialization
	void Start () {
	
		GameObject temp = GameObject.FindGameObjectWithTag ("LevelControl");//finds levelGenerator
		level = temp.GetComponent<LevelGenerator> ();// saved the script in level

		bombsPlaced = 0;
	//maxBomb
		maxBombs = 1;

		explodeRange = 1;
	}
	

	public void PlaceBomb(int x, int z){
		//check if possilbe to place bomb
		//1. if it has any bombs "left" to place
		if (maxBombs > bombsPlaced){
			//2. if possilbe place bomb under the player - Call bomb class - Emil dose this
		
				//3. call levelGenerator - and change 0 to eg 3 in the the array
			GameObject bombObject = level.PlaceObject(bomb,x,z, LevelGenerator.ObjectType.Bomb) as GameObject;

			Bomb bombScript = bombObject.GetComponent<Bomb>(); 
			bombScript.SetBombData(x,z, explodeRange, this);

		//4. increase bombPlaced
			bombsPlaced++;

		}

	}
	public void AfterExplosion(){
		bombsPlaced--;
	
	}

}
//arraycast - colliders 