using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	int score;
	int ball;
	TextMeshProUGUI textMeshProUGUI;
	Text text;
	int ballLeft;
	// Use this for initialization
	void Start () {
		ballLeft = ConfigurationUtils.BallLeft;
		textMeshProUGUI = gameObject.GetComponent<TextMeshProUGUI>();
		textMeshProUGUI.text = "Score: 0\n\nBall: "+ballLeft;
	}
	
	// Update is called once per frame
	void Update () {
		textMeshProUGUI.text = "Score: "+score+"\n\nBall: "+ballLeft;
		//text.text = "Score: "+score;
	}
	public void AddPoints(int score){
		this.score+=score;
	}
	public void DecreaseBall(){
		ballLeft--;
	}
}
