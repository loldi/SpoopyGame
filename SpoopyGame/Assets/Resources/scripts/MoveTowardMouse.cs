using UnityEngine;
using System.Collections;

public class MoveTowardMouse : MonoBehaviour {

	public float speed = 3.5f;
	private Vector3 target;

	// Use this for initialization
	void Start () {
		target = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		target.z = transform.position.z;
		transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
	}
}
