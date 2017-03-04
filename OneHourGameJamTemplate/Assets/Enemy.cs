using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public LayerMask playerMask;

	private bool movingRight;
	public void Initialize(bool right){
		movingRight = !right;
	}

	// Use this for initialization
	void Start () {
		Destroy (gameObject,10);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + Vector3.right * (movingRight?1:-1) * Time.deltaTime * 3;

	}

	public bool CheckSeen(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position,Vector3.right*(movingRight?1:-1),100,playerMask);

		return hit.collider != null;
		
	}


}
