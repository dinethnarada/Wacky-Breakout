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
	BallSpawner ballSpawner;
	float iNitXDir, iNitYDir;
	float ballXVelocity, ballYVelocity;
	float ballLifeTime;
	Timer timerOfBallLifeTime;
	Timer freezeTimer;
	float freezeTime = 1;
	
	// Use this for initialization
	void Start () {
		force = ConfigurationUtils.BallImpulseForse;
		rb2d = GetComponent<Rigidbody2D>();
		iNitXDir = Mathf.Cos(Mathf.PI*iNitDirection/180);iNitYDir = Mathf.Sin(Mathf.PI*iNitDirection/180);
		
		freezeTimer = gameObject.AddComponent<Timer>();
		freezeTimer.Duration = freezeTime;
		freezeTimer.Run();

		ballLifeTime = ConfigurationUtils.BallLifeTime;
		timerOfBallLifeTime = gameObject.AddComponent<Timer>();
		timerOfBallLifeTime.Duration = ballLifeTime;
		timerOfBallLifeTime.Run();
		ballSpawner = Camera.main.GetComponent<BallSpawner>();
	}
	// Update is called once per frame
	void Update () {
		if (timerOfBallLifeTime.Finished){				
			Destroy(gameObject);
			ballSpawner.SpawnNewBall();
		}
		if (freezeTimer.Finished&& !freezeTimer.AlreadyAddForce){
			rb2d.AddForce(new Vector2(iNitXDir*force,iNitYDir*force));
			freezeTimer.AlreadyAddForce = true;
		}
	}	
	public void SetDirection(Vector2 dir){
		print("parsein: "+ dir);
		ballXVelocity = rb2d.velocity.x; ballYVelocity = rb2d.velocity.y;
		print("before change: "+rb2d.velocity);
		rb2d.velocity = new Vector2(ballXVelocity*dir.x+ballYVelocity*dir.x,
		ballYVelocity*dir.y+ballXVelocity*dir.y);
		print("parseout: "+rb2d.velocity);
	}
}
