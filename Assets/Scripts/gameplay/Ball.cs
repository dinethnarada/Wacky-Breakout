using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// Ball move control
/// </summary>
public class Ball : MonoBehaviour {
	Rigidbody2D rb2d;
	float force;
	float iNitDirection = ConfigurationUtils.Direction;
	float iNitXDir, iNitYDir;
	float ballXVelocity, ballYVelocity;

	// Use this for initialization
	void Start () {
		force = ConfigurationUtils.BallImpulseForse;
		rb2d = GetComponent<Rigidbody2D>();
		iNitXDir = Mathf.Cos(Mathf.PI*iNitDirection/180);iNitYDir = Mathf.Sin(Mathf.PI*iNitDirection/180);
		rb2d.AddForce(new Vector2(iNitXDir*force,iNitYDir*force));
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void SetDirection(Vector2 dir){
		ballXVelocity = rb2d.velocity.x; ballYVelocity = rb2d.velocity.y;
		rb2d.velocity = new Vector2(ballXVelocity*dir.x+ballYVelocity*dir.x,
		ballYVelocity*dir.y+ballXVelocity*dir.y);
	}
}
