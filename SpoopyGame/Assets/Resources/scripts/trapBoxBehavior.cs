using UnityEngine;
using System.Collections;

public class trapBoxBehavior : MonoBehaviour {

	Animator anim;

	public float destroyTime = 60.2f;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (shootFrom.trapBoxPlaced) {
			if (Input.GetKeyDown (KeyCode.Space)) {
				anim.SetBool ("boxActivated", true);
			}
		}
		if (anim.GetBool ("boxActivated")) {
			destroyTime--;
		}
		if (destroyTime < 0) {
			Destroy (this.gameObject);
		}
	}
}
