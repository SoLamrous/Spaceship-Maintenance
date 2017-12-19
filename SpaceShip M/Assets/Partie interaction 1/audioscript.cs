using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioscript : MonoBehaviour {
	AudioSource aud;
	public bool right;
	InteractableItem it;
	// Use this for initialization
	void Start () {
		aud = gameObject.GetComponent<AudioSource> ();
		it = gameObject.GetComponent<InteractableItem> ();
		right = it.right;
	}
	
	// Update is called once per frame
	void Update () {
		if (it.IsInteracting ()) {
			if (right == false && Input.GetAxis ("leftbutton") > 0) {
				aud.Play ();
			}
			if (right == true && Input.GetAxis ("rightbutton") > 0) {
				aud.Play ();
			} else {
				aud.Stop ();
			}
		}
		
	}
}
