using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour {
	[SerializeField]
	Paddle paddle;
	Vector3 paddlePosition;
	[SerializeField]
	Block[] Blocks;
	
	float standardBlockWidth;float standardBlockHeight;
	int spawnBlockRows = 3; int spawnBlockColumns = 10;
	static float standardBlockProbability;
	static float bonusBlockProbability;
	static float pickUpBlockProbability;
	float[] probabilityArray = new float[3];
	Probability randomBlock;
	Vector2 standardBlockSpawnStartPosition;
	// Use this for initialization
	void Start () {
		standardBlockProbability = ConfigurationUtils.StandardBlockProbability;
		bonusBlockProbability = ConfigurationUtils.BonusBlockProbability;
		pickUpBlockProbability = ConfigurationUtils.PickUpBlockProbability;
		probabilityArray[0] = standardBlockProbability;
		probabilityArray[1] = bonusBlockProbability;
		probabilityArray[2] = pickUpBlockProbability;
		randomBlock = new Probability();
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
		standardBlockWidth = Blocks[0].transform.lossyScale.x;
		standardBlockHeight = Blocks[0].transform.lossyScale.y;
		float screenHeight = ScreenUtils.ScreenTop-ScreenUtils.ScreenBottom;
		float screenWidth = ScreenUtils.ScreenRight - ScreenUtils.ScreenLeft;
		standardBlockSpawnStartPosition = new Vector2 (ScreenUtils.ScreenLeft+screenWidth/2-spawnBlockColumns/2*standardBlockWidth, ScreenUtils.ScreenTop - screenHeight/5);	
		float spawnBlockStartX; float spawnBlockStartY = standardBlockSpawnStartPosition.y;	
		Vector2 spawnPosition;
		for (int y = 0; y<spawnBlockRows; y++){
			spawnBlockStartX=standardBlockSpawnStartPosition.x;
			for (int x = 0; x<spawnBlockColumns; x++){
				spawnPosition = new Vector2(spawnBlockStartX,spawnBlockStartY);				
				int randomBlockIndex =randomBlock.choose(probabilityArray);
				//Instantiate(Blocks[randomBlockIndex],spawnPosition,Quaternion.identity); // NORMAL
				Instantiate(Blocks[2],spawnPosition,Quaternion.identity); // TEST
				spawnBlockStartX += standardBlockWidth;			
			}
			spawnBlockStartY -= standardBlockHeight;
		}
	}
}
