using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Ball move control
/// </summary>
public class Ball : MonoBehaviour {
	Rigidbody2D rb2d;
	float force;
	float iNitDirection;
	float directionOffset;
	float randomDirection;
	BallSpawner ballSpawner;
	float iNitXDir, iNitYDir;
	float ballXVelocity, ballYVelocity;
	float BallVelocityVector;
	float ballLifeTime;
	Timer timerOfBallLifeTime;
	Timer waitTimer;
	Timer speedUpTimer;
	float speedUpFactor;
	float freezeTime = 1;
	
	// Use this for initialization

	void Start () {
		//PickUpBlock.speedUpEvent.AddListener(speedUp);
		speedUpTimer = gameObject.AddComponent<Timer>();
		speedUpFactor = ConfigurationUtils.SpeedUpFactor;
		EventManager.AddSpeedUpEventListener(speedUp);
		iNitDirection = ConfigurationUtils.Direction;
		directionOffset = ConfigurationUtils.DirectionOffset;
		randomDirection = Random.Range(iNitDirection-directionOffset,iNitDirection+directionOffset);
		force = ConfigurationUtils.BallImpulseForse;
		rb2d = GetComponent<Rigidbody2D>();
		iNitXDir = Mathf.Cos(Mathf.PI*randomDirection/180);iNitYDir = Mathf.Sin(Mathf.PI*randomDirection/180);		
		waitTimer = gameObject.AddComponent<Timer>();
		waitTimer.Duration = freezeTime;
		waitTimer.Run();
		
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
		if (waitTimer.Finished&& !waitTimer.AlreadyAddForce){
			rb2d.AddForce(new Vector2(iNitXDir*force,iNitYDir*force));
			waitTimer.AlreadyAddForce = true;
		}
		if (speedUpTimer.Finished&& !speedUpTimer.AlreadyAddForce){
			rb2d.velocity = new Vector2(rb2d.velocity.x/speedUpFactor,rb2d.velocity.y/speedUpFactor);
			speedUpTimer.AlreadyAddForce = true;
		}
	}	
	public void speedUp (int speedUpDuration,float speedUpFactor){
		if (!speedUpTimer.Running){
			rb2d.velocity *= speedUpFactor;
			speedUpTimer.Duration = speedUpDuration;
			speedUpTimer.Run();
		}		
	}
	public void SetDirection(Vector2 dir){
		//print("parsein: "+ dir);
		ballXVelocity = rb2d.velocity.x; ballYVelocity = rb2d.velocity.y;
		BallVelocityVector = Mathf.Sqrt(Mathf.Pow(ballXVelocity,2)+Mathf.Pow(ballYVelocity,2));
		//print("before change: "+rb2d.velocity);
		rb2d.velocity = new Vector2(BallVelocityVector*dir.x,BallVelocityVector*dir.y);
		//print("parseout: "+rb2d.velocity);
	}
}
