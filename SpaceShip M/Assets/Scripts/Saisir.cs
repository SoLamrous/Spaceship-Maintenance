using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Saisir : MonoBehaviour {
	bool inzone, holding;
	GameObject toGrab;
	Vector3 offset = new Vector3(0,0,0);
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		inzone = false;
		holding= false;
	}
	
	// Update is called once per frame
	void Update () {

		if(inzone ==true  && Input.GetButtonDown("leftTrigger")){
			if (offset.x == 0 && offset.y == 0 && offset.z == 0) {
				offset = toGrab.transform.position - transform.position;
				holding = true;
			}
		}
		if(holding)
			toGrab.transform.position = transform.position + offset ;
		if(holding && Input.GetButtonUp("leftTrigger")) {
			holding = false;
			offset = new Vector3 (0, 0, 0);

			rb.AddForce (transform.forward * 200);

			rb = null;
		}
		
	}

	void OnCollisionEnter(Collision c) {


		if (c.gameObject.CompareTag ("Object")) {
			inzone = true;
			toGrab = c.gameObject;
			rb = toGrab.GetComponent<Rigidbody> ();
		}
	}

	void OnCollisionExit(Collision c){
		if (toGrab == c.gameObject) {
			inzone = false;
			toGrab = null;

		}

			
	}
}
