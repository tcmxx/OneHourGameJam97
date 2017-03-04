using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

	public LayerMask playerMask;
	public Sprite supriseSprite;
	public SpriteRenderer rend;


	private bool movingRight;
	public void Initialize(bool right){
		movingRight = !right;
		rend.flipX = !right;
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
		bool seen = false;
		if(movingRight){
			if (GameController.gameController.currentHarri.transform.position.x > transform.position.x) {
				seen = true;
			}
		}else{
			if (GameController.gameController.currentHarri.transform.position.x < transform.position.x) {
				seen = true;
			}
		}


		if (seen) {
			ChangeSpriteToSurprise ();
			return true;
		}
		return false;
		
	}

	public void ChangeSpriteToSurprise(){
		rend.sprite = supriseSprite;
	}

}
