using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 
/// </summary>
public class Paddle:MonoBehaviour {
	Rigidbody2D rb2d;
	float velocityOfPeddle;	
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		velocityOfPeddle =  ConfigurationUtils.PaddleMoveUnitsPerSecond;
	}
	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		transform.Translate(new Vector3(velocityOfPeddle * horizontal,0,0));
	}	
}
