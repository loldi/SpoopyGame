using UnityEngine;
using System.Collections;

public class beamWeapon : MonoBehaviour {

	private LineRenderer lineRenderer;
	public Transform beamHit;
	public Transform beamTo;


	public float LineWidth;



	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = false;
		lineRenderer.useWorldSpace = true;



	}
	
	// Update is called once per frame
	void Update () {


		if (shootFrom.beamWeapon) {
			if (Input.GetMouseButton (0)) {

				//shootFrom.weaponEnergy.value -= .011f;
				lineRenderer.enabled = true;
				lineRenderer.SetPosition (0, transform.position);
				lineRenderer.SetPosition (1, beamTo.position);

			} else {

				//shootFrom.weaponEnergy.value +=.011f;

			}
			if (Input.GetMouseButtonUp (0) || shootFrom.outOfPower) {
				lineRenderer.enabled = false;
			}
		}
	}
}
