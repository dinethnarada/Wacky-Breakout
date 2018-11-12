using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpBlock : Block {
	[SerializeField]
	PickUpBlock[] pickUpBlock = new PickUpBlock[2];
	int effectChoose=1;
	
	#region Properties
	int EffectChoose{
		set{ 
			if (value<2&&value>0)
				effectChoose = value;
		}
	}
	#endregion
	// Use this for initialization
	public override void Start () {
		point = ConfigurationUtils.PickUpBlockPoints;
		GetComponent<SpriteRenderer>().color = pickUpBlock[effectChoose].GetComponent<SpriteRenderer>().color;
		base.Start();
	}
}
