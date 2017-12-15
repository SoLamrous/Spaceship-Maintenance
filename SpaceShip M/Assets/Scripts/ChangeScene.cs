using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public GameObject LeftHand;
	public GameObject RightHand;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider c) {
		if(c.gameObject.CompareTag("Hand")) {
			/*LeftHand.GetComponent<Deplacement>().changeAction(3);
			RightHand.GetComponent<Deplacement>().changeAction(3);
			*/SceneManager.LoadScene("testLab");
			//Application.LoadLevel ("testLab");
		}

	}
}
