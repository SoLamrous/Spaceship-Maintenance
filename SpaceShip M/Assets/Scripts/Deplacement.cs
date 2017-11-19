using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {
	bool inzone, holding;
	GameObject toGrab;
	public GameObject cam;
	Vector3 offset = new Vector3(0,0,0);
	Vector3 start;
	Vector3 end;
	Rigidbody rb;
	bool proj;

	// Use this for initialization
	void Start () {
		inzone = false;
		holding= false;
		rb = cam.GetComponent<Rigidbody> ();
		proj = false;
		//rb.AddForce ((transform.forward) * 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (inzone == true && Input.GetButtonDown ("leftTrigger")) {
			start = transform.position;
			holding = true;
			Debug.Log ("start");
		}
		if (holding && Input.GetButtonUp ("leftTrigger")) {
			end = transform.position;
			holding = false;
			rb.AddForce ((start-end) * 20);
		}
		
	}
	void OnCollisionEnter(Collision c) {


		if (c.gameObject.CompareTag ("wall")) {
			inzone = true;
			toGrab = c.gameObject;


		}
	}

	void OnCollisionExit(Collision c){
		if (toGrab == c.gameObject) {
			inzone = false;
			toGrab = null;


		}


	}

	void OnTriggerEnter(Collider c) {


		if (c.gameObject.CompareTag ("wall") && proj==false) {
			Debug.Log ("Projection");
			rb.AddForce (transform.forward * -1 * 2);
			proj = true;
		}
	}
	void OnTriggerExit(Collider c){
		proj = false;

	}

}
