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
	public bool Droite;
	string sideString;
	int action = 3; //Permets de limiter les déplacements à pousser(2) ou tirer(1), les deux (3)

	// Use this for initialization
	void Start () {
		inzone = false;
		holding= false;
		rb = cam.GetComponent<Rigidbody> ();
		proj = false;
		if (Droite) {
			sideString = "rightTrigger";
		} else {
			sideString = "leftTrigger";
		}
		//rb.AddForce ((transform.forward) * 200);
	}
	
	// Update is called once per frame
	void Update () {
		if (inzone == true && Input.GetButtonDown (sideString)) {
			start = transform.position;
			holding = true;
			Debug.Log ("start");
		}
		if (holding && Input.GetButtonUp (sideString)) {
			end = transform.position;
			holding = false;
			rb.AddForce ((start-end) * 20);
		}
		
	}
	void OnCollisionEnter(Collision c) {


		if (c.gameObject.CompareTag ("wall") && (action == 1 || action==3)) {
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


		if (c.gameObject.CompareTag ("wall") && proj==false && action > 1) {
			Debug.Log ("Projection");
			rb.AddForce (transform.forward * -1 * 2);
			proj = true;
		}
	}
	void OnTriggerExit(Collider c){
		proj = false;

	}

	public void changeAction(int actionPossible){
		action = actionPossible;
	}

}
