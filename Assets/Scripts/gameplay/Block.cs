using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour 
{
	protected int point;
	GameObject hUD;
	HUD scoreScript;	
	public virtual void Start () {
		hUD =  GameObject.FindWithTag("Score");
		scoreScript = hUD.GetComponent<HUD>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	protected virtual void OnCollisionEnter2D(Collision2D other) {
		//if (other.gameObject.CompareTag("Ball")){
			scoreScript.AddPoints(point);
			Destroy(gameObject);
		
	}
}
