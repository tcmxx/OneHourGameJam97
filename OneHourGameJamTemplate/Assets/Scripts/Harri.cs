using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harri : MonoBehaviour {

	public LayerMask doorMask;

	public float maxV = 1;
	Rigidbody2D rb;


	void Awake(){
		rb = GetComponent <Rigidbody2D> ();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void Move(float dir){
		rb.velocity = Vector3.right*dir*maxV;
	}

	public void Enter(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position,Vector3.forward,100,doorMask);
		Debug.Log ("Try");
		if (hit.collider != null) {
			GameController.gameController.Enter ();
			Debug.Log ("Enter");
		}
	}

}
