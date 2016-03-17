using UnityEngine;
using System.Collections;

public class laserSight : MonoBehaviour {

	private LineRenderer lineRenderer;
	public Transform beamHit;
	public Transform beamTo;
	
	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer> ();
		lineRenderer.enabled = true;
		lineRenderer.useWorldSpace = true;
	}
	
	// Update is called once per frame
	void Update () {
	    lineRenderer.SetPosition(0, transform.position);
		lineRenderer.SetPosition(1, beamTo.position);
	}

}