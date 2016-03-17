using UnityEngine;
using System.Collections;

public class beAtMouse : MonoBehaviour {

	private Vector3 mousePosition;
	public float moveSpeed = 0.1f;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position = Vector3.Lerp( new Vector3 (transform.position.x , transform.position.y, -5), mousePosition, moveSpeed);
		transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
	}
}