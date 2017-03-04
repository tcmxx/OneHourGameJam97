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
	public GameObject starPref;
	public Harri currentHarri;

	public int point;

	public float totalTimer;
	public readonly float  increaseDiffTime = 30.0f;
	float nextTime;

	public float timeLeft;
	public AudioClip background;
	public AudioClip gameover;

	void Awake(){
		gameController = this;
	}

	// Use this for initialization
	void Start () {
		Respawn ();
		point = 0;
		Invoke ("RandomInvoke",0.0f);
		totalTimer = 0;
		nextTime = Random.Range (3.0f, 8.0f);
		timeLeft = 60;
		AudioSource.PlayClipAtPoint (background,transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		totalTimer += Time.deltaTime;
		timeLeft -= Time.deltaTime;

		if (timeLeft <= 0) {
			Timeup ();
		}
		if (nextTime < totalTimer) {
			totalTimer = 0;
			Invoke ("RandomInvoke",0.0f);
			if(timeLeft < 20)
				nextTime = Random.Range (4.0f, 8.0f);
			else if(timeLeft < 40)
				nextTime = Random.Range (3.0f, 7.0f);
			else
				nextTime = Random.Range (2.0f, 6.0f);
		}
	}

	public void Respawn(){
		currentHarri = GameObject.Instantiate (harriPref,respawnPoint.position,respawnPoint.rotation).GetComponent <Harri>();
	}


	private void RandomInvoke(){
		RespawnEnemy (Random.Range (0, 100) > 30);
	}

	public void RespawnEnemy(bool right){
		Transform sp = right ? enemyPointRight : enemyPointLeft;
		Enemy emey = GameObject.Instantiate (enemyPref,sp.position,sp.rotation).GetComponent <Enemy>();
		emey.Initialize (right);
		print (right);
	}


	public void Enter(){
		if (!CheckWetherSeen ()) {
			Destroy (currentHarri.gameObject);
			GameObject.Destroy (GameObject.Instantiate (starPref,currentHarri.transform.position, currentHarri.transform.rotation),1);
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
				print ("seen");
				currentHarri.ChangeSurprise ();
				currentHarri.GetComponent <PlayerInput> ().enabled = false;
				return true;
			}
		}
		print ("not seen");
		return false;
	}

	public void Lose(){
		GameUI.ui.ShowLose ();
		AudioSource.PlayClipAtPoint (gameover,transform.position);
	}
	public void Timeup(){
		currentHarri.ChangeSurprise ();
		currentHarri.GetComponent <PlayerInput> ().enabled = false;
		GameUI.ui.ShowTimeUp ();
		AudioSource.PlayClipAtPoint (gameover,transform.position);
	}
	public void Restart(){
		Destroy (currentHarri.gameObject);
		Respawn ();
		point = 0;
		totalTimer = 0;
		timeLeft = 60;
	}
}
