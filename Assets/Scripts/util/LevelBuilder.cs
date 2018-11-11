using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
	[SerializeField]
	Paddle paddle;
	Vector3 paddlePosition;
	[SerializeField]
	StandardBlock standardBlock;
	float standardBlockWidth;float standardBlockHeight;
	int spawnBlockRows = 3; int spawnBlockColumns = 10;
	Vector2 standardBlockSpawnStartPosition;
	// Use this for initialization
	void Start () {
		SpawnPaddle();
		SpawnBlock();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void SpawnPaddle(){
		paddlePosition = new Vector3(0,-4,0);  //might fix later.
		Instantiate(paddle,paddlePosition,Quaternion.identity);	
	}
	void SpawnBlock(){
		standardBlockWidth = standardBlock.transform.lossyScale.x;
		standardBlockHeight = standardBlock.transform.lossyScale.y;
		float screenHeight = ScreenUtils.ScreenTop-ScreenUtils.ScreenBottom;
		float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
		standardBlockSpawnStartPosition = new Vector2 (ScreenUtils.ScreenLeft+screenWidth/2-spawnBlockColumns/2*standardBlockWidth, ScreenUtils.ScreenTop - screenHeight/5);	
		float spawnBlockStartX; float spawnBlockStartY = standardBlockSpawnStartPosition.y;	
		Vector2 spawnPosition;
		for (int y = 0; y<spawnBlockRows; y++){
			spawnBlockStartX=standardBlockSpawnStartPosition.x;
			for (int x = 0; x<spawnBlockColumns; x++){
				spawnPosition = new Vector2(spawnBlockStartX,spawnBlockStartY);
				Instantiate(standardBlock,spawnPosition,Quaternion.identity);
				spawnBlockStartX += standardBlockWidth;
			}
			spawnBlockStartY -= standardBlockHeight;
		}
	}
}
