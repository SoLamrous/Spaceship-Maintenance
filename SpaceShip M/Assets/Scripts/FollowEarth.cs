using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEarth : MonoBehaviour {
	public GameObject earth;
	// Use this for initialization
	void Start () {
		transform.position = GetComponentInParent<Transform> ().position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = GetComponentInParent<Transform> ().position;
	}
}
