using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attach : MonoBehaviour {
	public GameObject particule;
	public GameObject bout1;
	public GameObject bout2;
	 bool isattached=false;
	Rigidbody rb1;
	Rigidbody rb2;
	// Use this for initialization
	void Start () {
		rb1 = bout1.GetComponent<Rigidbody> ();
		rb2 = bout2.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider other) {


		if (other.gameObject.name=="boutfix") {
			rb1.isKinematic = true;
			rb2.isKinematic = true;
			isattached = true;
			//particule.SetActive(true);
		}
		if (other.gameObject.name == "feu") {
			if (isattached)
				particule.SetActive (true);
		}
	}
	void OnTriggerExit(Collider other) {
		//Debug.Log (other.name);
		if (other.gameObject.name=="feu") {

			particule.SetActive(false);
		}
		//
		//plus = true;
	}
}
