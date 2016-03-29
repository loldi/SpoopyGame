using UnityEngine;
using System.Collections;

public class whatFriendCanSee : MonoBehaviour {

	public bool canSeePlayer;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Ghost"){
			canSeePlayer=true;
		}
	}
}
