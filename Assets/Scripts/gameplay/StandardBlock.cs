using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBlock : Block {
	[SerializeField]
	Block[] standardBlocks = new StandardBlock[3];
	// Use this for initialization
	public override void Start () {
		point = ConfigurationUtils.StandardBlockPoints;
		int random =  Random.Range(0,3);		
		SpriteRenderer randomSpriteRenderer = standardBlocks[random].GetComponent<SpriteRenderer>();
		this.GetComponent<SpriteRenderer>().color =  randomSpriteRenderer.color;
		base.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
