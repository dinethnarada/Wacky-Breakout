using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUpBlock : Block {
	[SerializeField]
	PickUpBlock[] pickUpBlock = new PickUpBlock[2];
	int freezeDuration;
	int speedUpDuration;
	float speedUpFactor;
	FreezeEventActivated freezeEvent;
	public static SpeedUpEventActivated speedUpEvent;
	PickupEffect pickupEffect;
	
	#region Properties
	PickupEffect Effect{
		get{ return pickupEffect;}
		set{
			pickupEffect = value;
			GetComponent<SpriteRenderer>().color = pickUpBlock[(int)pickupEffect].GetComponent<SpriteRenderer>().color;
			switch(value){			
				case (PickupEffect.Freezer):
				{
					freezeEvent = new FreezeEventActivated();
					freezeDuration = ConfigurationUtils.FreezeDuration;
					EventManager.AddFreezeInvoker(this);
					break;
				}
				case (PickupEffect.Speedup):
				{
					speedUpEvent = new SpeedUpEventActivated();
					speedUpDuration = ConfigurationUtils.SpeedUpDuration;
					speedUpFactor = ConfigurationUtils.SpeedUpFactor;
					EventManager.AddSpeedUpEventInvoker(this);
					break;
				}
			}
		}
	}
	#endregion
	// Use this for initialization
	public override void Start () {
		int enumLength = System.Enum.GetNames(typeof(PickupEffect)).Length;
		Effect = (PickupEffect)UnityEngine.Random.Range(0, enumLength);
		point = ConfigurationUtils.PickUpBlockPoints;
		base.Start();
	}
	protected override void OnCollisionEnter2D(Collision2D other) { // don't change default value name.
		if ( Effect == PickupEffect.Freezer){
			freezeEvent.Invoke(freezeDuration);
		} 
		if (Effect == PickupEffect.Speedup){
			speedUpEvent.Invoke(speedUpDuration,speedUpFactor);
		}
		base.OnCollisionEnter2D(other);
	}
	public void AddFreezeEventListener(UnityAction<int> freezeEventHandler){
		freezeEvent.AddListener(freezeEventHandler);
	}
	public void AddSpeedUpEventListener(UnityAction<int,float> speedUpEventHandler){
		speedUpEvent.AddListener(speedUpEventHandler);
	}
}
