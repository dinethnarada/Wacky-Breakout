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
	float halfHeightOfPeddle;
	bool IsTop;
	float returnX;
	float positionY;
	const float BounceAngleHalfRange = Mathf.PI*60/180;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();		
		halfWidthOfPeddle = transform.lossyScale.x/2;
		halfHeightOfPeddle = transform.lossyScale.y/2;
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
	   /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
		IsTop = TopCollisionDetact(coll);
        if (coll.gameObject.CompareTag("Ball")&&IsTop)
        {	
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfWidthOfPeddle;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)); 
            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
	bool TopCollisionDetact(Collision2D coll){
		float collisionY = coll.GetContact(0).point.y;
		float topY = transform.position.y+halfHeightOfPeddle;
		if (collisionY <=topY+0.05&&collisionY>=topY-0.05)
			return true;
		else return false;	
	}
}
