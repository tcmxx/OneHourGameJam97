using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	public Text point;
	public GameObject loosePanel;
	public GameObject tiimePanel;
	public Text time;
	static public GameUI ui;
	void Awake(){

		ui = this;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		point.text = "Point:" + GameController.gameController.point;
		time.text = "Time Left: " + GameController.gameController.timeLeft.ToString ("F1");
	}

	public void ShowLose(){
		loosePanel.SetActive (true);
	}
	public void ShowTimeUp(){
		tiimePanel.SetActive (true);
	}
}
