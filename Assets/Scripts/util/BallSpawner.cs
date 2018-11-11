using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour {
    public Ball ballPrefab;
    float minSpawnTime;
    float maxSpawnTime;
    float randomSpawnTime;
    Vector2 ballDownLeftCorner;
    Vector2 ballUpRightCorner;
    Timer spawnTimer;
    bool RetrySpawn = false;
    private void Start() {
        Ball ball = Instantiate(ballPrefab,Vector3.zero,Quaternion.identity);
        Vector3 scaleOfBall =  ball.transform.lossyScale;
        float ballHalfWidth = scaleOfBall.x/2.0f;
        float ballHalfHeight = scaleOfBall.y/2.0f;
        ballDownLeftCorner = new Vector2(ball.transform.position.x-ballHalfWidth,ball.transform.position.y-ballHalfHeight);
        ballUpRightCorner = new Vector2(ball.transform.position.x+ballHalfWidth,
        ball.transform.position.y+ballHalfHeight);
        minSpawnTime = ConfigurationUtils.MinSpawnTime;
        maxSpawnTime = ConfigurationUtils.MaxSpawnTime;
        spawnTimer = gameObject.AddComponent<Timer>();
        RunRandomSpawnTimer(spawnTimer);
        Destroy(ball.gameObject);
    }
    private void Update() {
        if (spawnTimer.Finished || RetrySpawn){
            SpawnNewBall();
            RunRandomSpawnTimer(spawnTimer);
        }
    }
    public void SpawnNewBall(){
        if (Physics2D.OverlapArea(ballDownLeftCorner,ballUpRightCorner)==null){
            Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);         
            RetrySpawn=false;
        }else{
            RetrySpawn=true;
        } 
    }
    /// <summary>
    /// if the ball exit downside of screen, spawn a new ball
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit2D(Collider2D other) {
        Destroy(other.gameObject);
        SpawnNewBall();
    }
    public void RunRandomSpawnTimer(Timer timer){
        randomSpawnTime =  Random.Range(minSpawnTime,maxSpawnTime+1);
        timer.Duration = randomSpawnTime;
        timer.Run();
    }
}
