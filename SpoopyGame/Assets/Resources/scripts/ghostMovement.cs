using UnityEngine;
using System.Collections;

public class ghostMovement : MonoBehaviour {

	public int movementSpeed = 3;
	private float hereGoesSubjectLine = 0;
	private float subjectLine;
	private int dir = 1;
	private Transform target;
	private float zTarget;
	public float rotationSpeed;
	public bool playerSight = false;
	public int initial;
	public float zOffset;


	 TrailRenderer tr;

	// Use this for initialization
	void Start () {
		subjectLine = Random.Range(60, 360);
		target = GameObject.Find("player").transform;
		tr = gameObject.GetComponent<TrailRenderer> ();

		tr.sortingLayerName = "Ghosts";
	}
	
	// Update is called once per frame
	void Update () {
		if (playerSight == false){
			if(GameObject.Find("SightRange").GetComponent<whatGhostCanSee>().canSeePlayer == true){
				movementSpeed = 4;
				playerSight = true;
			}
		}

		transform.position += -transform.up * Time.deltaTime * movementSpeed;

		if (playerSight == false){
			if (dir == 1){
				hereGoesSubjectLine++;
				if (hereGoesSubjectLine >= subjectLine){
					dir = 2;
					subjectLine = Random.Range(0, 100);
				}
			}
			if (dir == 2){
				hereGoesSubjectLine = hereGoesSubjectLine-1;
				if (hereGoesSubjectLine <= subjectLine){
					dir = 1;
					subjectLine = Random.Range(260, 360);
				}
			}
		} else {
			Vector3 difference = target.position - transform.position;
			difference.Normalize ();
			zTarget = Mathf.Atan2 (difference.y, difference.x) * Mathf.Rad2Deg;
			if (zTarget+zOffset > initial+hereGoesSubjectLine+1){
				hereGoesSubjectLine = hereGoesSubjectLine+rotationSpeed;
			} else if (zTarget+zOffset < initial+hereGoesSubjectLine-1){
				hereGoesSubjectLine = hereGoesSubjectLine-rotationSpeed;
			}
		}
		transform.rotation = Quaternion.Euler (0f, 0f, initial+hereGoesSubjectLine);

		if (ghostHP.ghostHealth <= 0) {

			Destroy (this.gameObject);

		}
	}

	void OnCollisionEnter2D(Collision2D other){

		if (other.gameObject.tag == "GhostPal") {

			Destroy (this.gameObject);

			Debug.Log ("ghost pal doin WORK");

		}


	}

}

