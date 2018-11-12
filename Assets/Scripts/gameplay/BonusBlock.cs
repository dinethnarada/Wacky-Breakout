using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusBlock : Block {
    [SerializeField]
    Block bonusBlock;
	// Use this for initialization
	public override void Start () {
		point = ConfigurationUtils.BonusBlockPoints;
        this.GetComponent<SpriteRenderer>().color = bonusBlock.GetComponent<SpriteRenderer>().color;
        base.Start();
	}
}
