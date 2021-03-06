﻿
using UnityEngine;
using System.Collections;



public class LevelGenerator : MonoBehaviour {

	public enum ObjectType {
		Path = 0,
		Wall_solid = 1,
		Crate = 2,
		Bomb = 4,
		PowerUp = 5,
	};

	public Transform Crate;
	public Transform Wall_solid;
	
	private const int xSize = 23; 
	private const int zSize = 19;

	public int[,] LevelGen = new int[zSize,xSize]		
	{	{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
		{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,2,1,2,1,2,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,2,2,0,2,2,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,2,1,2,1,2,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,2,2,2,2,2,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1,0,1 },
		{ 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
		{ 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
	};
	
	
	void Start () {
		
		GameObject[,] level = new GameObject[zSize,xSize];
		for (int z=0 ; z<zSize ; z++){
			for (int x=0 ; x<xSize ; x++){
				if(LevelGen[z,x] == 1)
					level[z,x] = PlaceObject(Wall_solid,x,z,ObjectType.Wall_solid) as GameObject; //Instantiate(Wall_solid, new Vector3(x*2.0f-xSize+1, 0.0f, -z*2.0f+zSize-1), Quaternion.identity) as GameObject;
				
				if(LevelGen[z,x] == 2)
					level[z,x] = PlaceObject(Crate,x,z,ObjectType.Crate) as GameObject;//Instantiate(Crate, new Vector3(x*2.0f-xSize+1, 0.0f, -z*2.0f+zSize-1), Quaternion.identity) as GameObject;
				
				
			}
		}
		
	}
	
	void Update () {
		
	}
	// CheckPosition FUNCTION 
	/// <summary>
	/// 
	/// </summary>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	public int CheckPosition(int x,int z)
	{
		return LevelGen[z,x];

	}
	/// <summary>
	/// Places the object.
	/// </summary>
	/// <returns>The object.</returns>
	/// <param name="original">Original.</param>
	/// <param name="x">The x coordinate.</param>
	/// <param name="z">The z coordinate.</param>
	public Object PlaceObject(Object original, int x, int z, ObjectType type)
	{
		LevelGen[z,x] = (int)type;
		return Instantiate(original, new Vector3(x*2.0f-xSize+1, 0.0f, -z*2.0f+zSize-1), Quaternion.identity);

	}


}

