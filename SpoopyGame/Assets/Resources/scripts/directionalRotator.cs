using UnityEngine;
using System.Collections;

public class directionalRotator : MonoBehaviour {
	private Animator anim; 


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftShift)){
			anim.SetBool("running", true);
		} else {
			anim.SetBool("running", false);
		}
		if (Input.GetKey(KeyCode.W)){
			if (Input.GetKey(KeyCode.A)){
				transform.rotation = Quaternion.Euler(0, 0, 225);
				anim.SetBool("moving", true);
			} else if (Input.GetKey(KeyCode.D)){
				transform.rotation = Quaternion.Euler(0, 0, 135);
				anim.SetBool("moving", true);
			} else {
				transform.rotation = Quaternion.Euler(0, 0, 180);
				anim.SetBool("moving", true);
			}
		} else if (Input.GetKey(KeyCode.S)){
			if (Input.GetKey(KeyCode.A)){
				transform.rotation = Quaternion.Euler(0, 0, 315);
				anim.SetBool("moving", true);
			} else if (Input.GetKey(KeyCode.D)){
				transform.rotation = Quaternion.Euler(0, 0, 45);
				anim.SetBool("moving", true);
			} else {
				transform.rotation = Quaternion.Euler(0, 0, 0);
				anim.SetBool("moving", true);
			}
		} else if (Input.GetKey(KeyCode.A)){
			transform.rotation = Quaternion.Euler(0, 0, 270);
			anim.SetBool("moving", true);
		} else if (Input.GetKey(KeyCode.D)){
			transform.rotation = Quaternion.Euler(0, 0, 90);
			anim.SetBool("moving", true);
		} else
		anim.SetBool("moving", false);


	}
}
