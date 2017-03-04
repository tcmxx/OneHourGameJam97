using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class GameController : MonoBehaviour {

	public static GameController gameController;
	public GameObject harriPref;
	public GameObject enemyPref;
	public Transform respawnPoint;
	public Transform enemyPointRight;
	public Transform enemyPointLeft;
	Harri currentHarri;

	public int point;

	void Awake(){
		gameController = this;
	}

	// Use this for initialization
	void Start () {
		Respawn ();
		point = 0;
		InvokeRepeating ("RandomInvoke", 2f,4.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Respawn(){
		currentHarri = GameObject.Instantiate (harriPref,respawnPoint.position,respawnPoint.rotation).GetComponent <Harri>();
	}


	private void RandomInvoke(){
		RespawnEnemy (Random.Range (0, 1) > 0.5f);
	}

	public void RespawnEnemy(bool right){
		Transform sp = right ? enemyPointRight : enemyPointLeft;
		Enemy emey = GameObject.Instantiate (enemyPref,sp.position,sp.rotation).GetComponent <Enemy>();
		emey.Initialize (right);
	}


	public void Enter(){
		if (!CheckWetherSeen ()) {
			Destroy (currentHarri.gameObject);
			Respawn ();
			point++;
		} else {
			Lose ();
		}
	}

	public bool CheckWetherSeen(){
		GameObject[] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		foreach (var enemy in enemies) {
			if (enemy.GetComponent <Enemy> ().CheckSeen ()) {
				return true;
			}
		}

		return false;
	}

	public void Lose(){
	}
}
