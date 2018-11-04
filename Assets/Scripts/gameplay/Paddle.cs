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
	float halfWidthOfPeddle;
	float returnX;
	float positionY;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();		
		halfWidthOfPeddle = transform.lossyScale.x/2;
		Debug.Log(halfWidthOfPeddle);
		velocityOfPeddle =  ConfigurationUtils.PaddleMoveUnitsPerSecond;
		positionY = transform.position.y;
	}
	void FixedUpdate() {
		float horizontal = Input.GetAxis("Horizontal");
		//transform.Translate(new Vector3(velocityOfPeddle * horizontal,0,0));
		float possibleX = transform.position.x+velocityOfPeddle*horizontal;	
		float returnX = CalculateClampedX(possibleX,horizontal);
		Vector2 newPosition = new Vector2(returnX,positionY);
		rb2d.MovePosition(newPosition);
	}
	public float CalculateClampedX(float x,float direction){
		if (x - halfWidthOfPeddle < ScreenUtils.ScreenLeft||x + halfWidthOfPeddle > ScreenUtils.ScreenRight)
			return transform.position.x;
			else return (x);
	}
}
