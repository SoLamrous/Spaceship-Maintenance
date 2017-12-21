using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour {
	bool inzone, holding;
	GameObject toGrab;
	public GameObject cam;
	public bool droite;
	string Side;
	Vector3 offset = new Vector3(0,0,0);
	Vector3 start;
	Vector3 end;
	Rigidbody rb;

	bool proj;
	public float maxVelocity = 5f;
	ParticleSystem.EmissionModule emission;


	public float mult = 10f;

	// Use this for initialization
	void Start () {
		if (droite)
			Side = "right";
		else
			Side = "left";
		inzone = false;
		holding= false;
		rb = cam.GetComponent<Rigidbody> ();
		proj = false;
		emission = GetComponentInChildren<ParticleSystem> ().emission;


		emission.enabled = false;
		//rb.AddForce ((transform.forward) * 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.magnitude > maxVelocity) {
			if(Input.GetButton (Side + "Trigger"))
				rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxVelocity/10f);
			else
				rb.velocity = Vector3.ClampMagnitude (rb.velocity, maxVelocity);
		}
		if (Input.GetButton (Side + "Pad")) {
			if (droite)
				rb.AddForce (transform.forward * mult);
			else
				rb.AddForce (transform.forward * -1 * mult);
			emission.enabled = true;
		} else {
			if(emission.enabled) emission.enabled = false;
			if (inzone == true && Input.GetButtonDown (Side + "Trigger")) {
				start = transform.position;
				holding = true;
				Debug.Log ("start");
			}
			if (holding && Input.GetButtonUp (Side + "Trigger")) {
				end = transform.position;
				holding = false;
				rb.AddForce ((start - end) * 20);
			}
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
