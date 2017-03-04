using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {
	public Text point;
	public GameObject loosePanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		point.text = "Point:" + GameController.gameController.point;
		
	}

	public void ShowLose(){
		loosePanel.SetActive (true);
	}
}
