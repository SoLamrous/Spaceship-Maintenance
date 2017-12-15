using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateCollider : MonoBehaviour {
	float t=100f;
	Collider c;
	// Use this for initialization
	void Start () {
		c = GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!c.enabled) {
			if (t > 0) {
				t--;
			} else {
				c.enabled = true;
			}
			
		}
	}
}