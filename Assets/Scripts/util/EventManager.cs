using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class EventManager
{
	static PickUpBlock freezeEventInvoker;
	static UnityAction<int> freezeEventListener;
	static PickUpBlock speedUpEventInvoker;
	static UnityAction<int,float> speedUpEventListener;
	public static void AddFreezeInvoker(PickUpBlock invoker){
		freezeEventInvoker = invoker;
		if ( freezeEventListener != null){
			freezeEventInvoker.AddFreezeEventListener(freezeEventListener);
		}
	} 
	public static void AddFreezeListener(UnityAction<int> freezeEventHandler){
		freezeEventListener = freezeEventHandler;
		if ( freezeEventInvoker != null){
			freezeEventInvoker.AddFreezeEventListener(freezeEventListener);
		}
	}
	public static void AddSpeedUpEventInvoker(PickUpBlock invoker){
		speedUpEventInvoker = invoker;	
		if ( speedUpEventListener != null){
			speedUpEventInvoker.AddSpeedUpEventListener(speedUpEventListener);
			Debug.Log("Inadd");
		}
	}
	public static void AddSpeedUpEventListener(UnityAction<int,float> speedUpEventHandler){
		speedUpEventListener = speedUpEventHandler;
		if (speedUpEventInvoker != null){
			speedUpEventInvoker.AddSpeedUpEventListener(speedUpEventListener);
			Debug.Log("Liadd");
		}
	}
}
