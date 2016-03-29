using UnityEngine;
using System.Collections;

public class swirlScript : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "Ghost") {

			shootFrom.ghostCaptured = true;
			Debug.Log ("ghost hit");
			Destroy (other.gameObject);

		}

	}
}
