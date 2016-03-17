using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	
	public float speed = 4.0f;
	public GameObject splatBullet;
	public float horiz;
	public float vert;
	
	void Update() {

		horiz = Input.GetAxis("Horizontal");
		vert = Input.GetAxis("Vertical");
		var move = new Vector3(horiz, vert, 0);
		transform.position += move * speed * Time.deltaTime;

		if (Input.GetKey(KeyCode.LeftShift)){
			speed = 6.0f;
		} else {
			speed = 4.0f;
		}

	}


//	void OnTriggerEnter2D(Collider2D other) {
//
//		if (other.gameObject.tag == "Hallway") {
//
//			Debug.Log ("You've entered the hallway!");
//
//		} else if (other.gameObject.tag == "Room") {
//
//			Debug.Log ("You've entered a Room!");
//		} else {
//
//			Debug.Log ("You are somewhere else!");
//		}
//		
//	}

}