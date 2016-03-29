using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float regularSpeed = 5.0f;
	public float dashModifier = 2.0f;
	public float currentSpeed = 5.0f;
	public float horiz;
	public float vert;
	
	void Update() {

		horiz = Input.GetAxis("Horizontal");
		vert = Input.GetAxis("Vertical");
		var move = new Vector3(horiz, vert, 0);
		transform.position += move * currentSpeed * Time.deltaTime;

		if (Input.GetKey(KeyCode.LeftShift)){
			currentSpeed = regularSpeed + dashModifier;
		} else {
			currentSpeed = regularSpeed;
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