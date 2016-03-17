using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ghostHP : MonoBehaviour 
{
    [SerializeField]
    Color start;
    [SerializeField]
    Color end;

    [SerializeField]
    Material CircleMaterial;

	public static float ghostHealth = 1.0f;

	public GameObject ghost;


	// Update is called once per frame
	void Update () 
    {

		if (ghost != null) {
			//ghostHealth -= .02f;

			CircleMaterial.SetFloat ("_Angle", Mathf.Lerp (-3.14f, 3.14f, ghostHealth));
			CircleMaterial.SetColor ("_Color", Color.Lerp (start, end, ghostHealth));

			transform.position = new Vector2 (ghost.transform.position.x, ghost.transform.position.y + 1.5f);
		}
	}
}
