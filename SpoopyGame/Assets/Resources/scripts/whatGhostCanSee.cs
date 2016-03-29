using UnityEngine;
using System.Collections;

public class whatGhostCanSee : MonoBehaviour {
	
	public bool canSeePlayer = false;

	void Start() {
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player"){
			canSeePlayer=true;
		}
	}
}
