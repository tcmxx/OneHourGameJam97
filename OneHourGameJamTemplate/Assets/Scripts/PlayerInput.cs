using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	Harri harri;

	void Awake(){
		harri = GetComponent <Harri> ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		harri.Move (Input.GetAxis ("Horizontal"));
		if (Input.GetButtonDown ("Enter")) {
			harri.Enter ();
		}
	}
}
