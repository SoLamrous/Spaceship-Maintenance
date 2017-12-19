using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class Saisir : MonoBehaviour {
	bool inzone, holding;

	HashSet<InteractableItem> objectsHoveringOver = new HashSet<InteractableItem>();

	private InteractableItem closestItem;
	private InteractableItem interactingItem;

	GameObject toGrab;
	Vector3 offset = new Vector3(0,0,0);
	Rigidbody rb;
	string Side;
	public bool droite=false;
	// Use this for initialization
	void Start () {
		if (droite)
			Side = "rightTrigger";
		else
			Side = "leftTrigger";
		inzone = false;
		holding= false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown(Side)) {
			Debug.Log ("down");
			float minDistance = 2.0f;

            float distance;
            foreach (InteractableItem item in objectsHoveringOver) {
                distance = (item.transform.position - transform.position).sqrMagnitude;

                if (distance < minDistance) {
                    minDistance = distance;
                    closestItem = item;
                }
            }

            interactingItem = closestItem;

            if (interactingItem) {
                if (interactingItem.IsInteracting()) {
                    interactingItem.EndInteraction(gameObject);
                }

                interactingItem.BeginInteraction(gameObject);
				if (droite)
					interactingItem.right = true;
				else
					interactingItem.right = false;
            }
        }

		if (Input.GetButtonUp(Side) && interactingItem != null) {
            interactingItem.EndInteraction(gameObject);
        }
	}
	private void OnTriggerEnter(Collider collider) {
		Debug.Log ("trigger enter");
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem) {
            objectsHoveringOver.Add(collidedItem);
        }
    }

    private void OnTriggerExit(Collider collider) {
        InteractableItem collidedItem = collider.GetComponent<InteractableItem>();
        if (collidedItem) {
            objectsHoveringOver.Remove(collidedItem);
        }
    }
}

