using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if (screenPosition.y > Screen.height || screenPosition.y < 0) { 
			Destroy(this.gameObject); 		
		}


	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall") {
			Destroy (this.gameObject);
			Debug.Log ("hit wall");

		}

		if (coll.gameObject.tag == "Ghost") {
			Destroy (this.gameObject);
			ghostHP.ghostHealth -= 0.2f;
		}

	}

}
