using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class shootFrom : MonoBehaviour {

	public float speed = 4.0f;
	//public GameObject splatBullet;

	public GameObject tank;
	public Rigidbody2D bulletYellow;

	public GameObject normal;
	public GameObject beam;
	public GameObject trapBox;

	public GameObject trapBoxReal;

	public  Slider weaponEnergy;

	public float attackSpeed = 2.0f;
	public float coolDown = 0;

	public static bool normalWeapon;
	public static bool beamWeapon;
	public static bool trapBoxWeapon;

	public static bool trapBoxPlaced;

	//bool normalFire;
	bool beamFire;
	public static bool outOfPower;

//	Animator trapBoxActivate;


	// Use this for initialization
	void Start () {
		
		outOfPower = false;

		normalWeapon = true;
		beamWeapon = false;
		trapBoxWeapon = false;

		normal.SetActive(true);
		beam.SetActive(false);
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonUp (0)) {

			beamFire = false;
			//normalFire = false;

		}

		if (Input.GetKeyDown (KeyCode.Alpha3)) {

			normal.SetActive(false);
			beam.SetActive(false);
			trapBox.SetActive (true);

			normalWeapon = false;
			beamWeapon = false;
			trapBoxWeapon = true;


		}

		if(Input.GetKeyDown(KeyCode.Alpha2)){

			normal.SetActive(false);
			beam.SetActive(true);
			trapBox.SetActive (false);

			normalWeapon = false;
			beamWeapon = true;
			trapBoxWeapon = false;
			

		}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {

			normal.SetActive(true);
			beam.SetActive(false);
			trapBox.SetActive (false);

			normalWeapon = true;
			beamWeapon = false;
			trapBoxWeapon = false;

		}


		if (normalWeapon && (Time.time >= coolDown)) {

			if (Input.GetMouseButtonDown (0)) {

				coolDown = Time.time + attackSpeed;

				Quaternion tankRotationOffset = tank.transform.rotation;
				tankRotationOffset.eulerAngles = new Vector3 (tank.transform.rotation.eulerAngles.x, tank.transform.rotation.eulerAngles.y, tank.transform.rotation.eulerAngles.z - 90.0f);
				Rigidbody2D bPrefab = Instantiate (bulletYellow, new Vector3 (tank.transform.position.x, tank.transform.position.y, tank.transform.position.z), tankRotationOffset) as Rigidbody2D;
				bPrefab.transform.parent = tank.transform;
				bPrefab.transform.localPosition = new Vector3 (1.0f, 0.0f, 0.0f);
				bPrefab.transform.parent = null;
				bPrefab.AddForce (tank.transform.right * speed);
			} 
		


		}

		if (trapBoxWeapon) {

			if (Input.GetMouseButtonDown (0)) {

				Instantiate (trapBoxReal, new Vector2 (tank.transform.position.x, tank.transform.position.y), Quaternion.identity);
				trapBoxPlaced = true;
				trapBoxWeapon = false;

			}
		}
			
		if(beamWeapon){

			if (Input.GetMouseButton(0) && !outOfPower) {

				beamFire = true;


				if (beamFire) {
					weaponEnergy.value -= .011f;
				}

			}
		}

		if (weaponEnergy.value < 1 && !beamFire) {

		
				weaponEnergy.value += .011f;

			}

		if (weaponEnergy.value == 0) {

			outOfPower = true;


		} else if (weaponEnergy.value > 0) {


			outOfPower = false;
		}

		}

	}

	


