using UnityEngine;
using System.Collections;

public class ghostMovement : MonoBehaviour {

	public int movementSpeed = 3;
	private int hereGoesSubjectLine = 0;
	private int subjectLine;
	private int dir = 1;
	public int initial;

	 TrailRenderer tr;

	// Use this for initialization
	void Start () {
		subjectLine = Random.Range(60, 360);

		tr = gameObject.GetComponent<TrailRenderer> ();

		tr.sortingLayerName = "Ghosts";
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += -transform.up * Time.deltaTime * movementSpeed;
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
		transform.rotation = Quaternion.Euler (0f, 0f, initial+hereGoesSubjectLine);


		if (ghostHP.ghostHealth <= 0) {

			Destroy (this.gameObject);

		}
	}


	void OnCollisionEnter2D(Collision2D other){


		if (other.gameObject.tag == "Swirl") {

			ghostHP.ghostHealth -= 100.0f;

		}


	}


}

