﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bomb : MonoBehaviour {

	//Timer
	private float timer = 0.0f;//start timer
	private float timerMax = 3.0f;

	// - explodeGange
	private float explodeRange;

	private int x;
	private int z;
	private BombBag playerBag;



	 void Start (){
	}

	void Update(){
			//timerCount
		timer += Time.deltaTime;
		// checker if time is equal to or bigger than timerMax, is important because it is floats
		if (timer >= timerMax)
		{
			Explode ();
		}

	}

	private void Explode(){
		float up, down, left, right;

		RaycastHit hit;
		//right
		List<Collider> hitObjects = new List<Collider>();

		if (Physics.Raycast (this.transform.position, new Vector3 (1, 0, 0), out hit, explodeRange)) {
			right = hit.distance;//distance is the distance between where we send the ray from and where we hit something.
			hitObjects.Add(hit.collider);
		}else{
			right = explodeRange;//if we dont hit anything, then the bomb eplode out in the explode range
		}
		//left
		if (Physics.Raycast (this.transform.position, new Vector3 (-1, 0, 0), out hit, explodeRange)) {
			left = hit.distance;
			hitObjects.Add(hit.collider);
		}else{
			left = explodeRange;
		}
		//up
		if (Physics.Raycast (this.transform.position, new Vector3 (0, 0, 1), out hit, explodeRange)) {
			up = hit.distance;
			hitObjects.Add(hit.collider);
		} else {
			up = explodeRange;
		}
		//down
		if (Physics.Raycast (this.transform.position, new Vector3 (0, 0, -1), out hit, explodeRange)) {
			down = hit.distance;
			hitObjects.Add(hit.collider);
		} else {
			down = explodeRange;
		}

		for (int i = 0; i < hitObjects.Count; i++) {
			GameObject obj = hitObjects[i].gameObject;
			if(obj.tag== "Crate")
				Destroy(obj);
			else if(obj.tag == "Player")
				Destroy(obj);
		}



		//call playerBag to say that bomb is exploded/destroyed - so bombBag will create new bomb. This is done by decresing bombPlaced
		//Instantiate the explosion and explode!!!
		Destroy (gameObject);
		playerBag.AfterExplosion ();
	}


	public void SetBombData(int x, int z, int radius, BombBag playerBag){
		this.x = x;
		this.z = z;
		this.explodeRange = radius;
		this.playerBag = playerBag;

	}


}
