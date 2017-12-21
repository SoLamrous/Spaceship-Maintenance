using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bouncing : MonoBehaviour {
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision c){
		if (c.gameObject.CompareTag ("wall")) {
			ContactPoint contact = c.contacts [0];
			rb.AddForce (contact.normal * 0.001f);
		}
	}
}
