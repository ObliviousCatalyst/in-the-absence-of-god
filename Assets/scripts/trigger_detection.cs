using UnityEngine;

public class trigger_detection : MonoBehaviour {
	public bool playerDetected = false;

	public void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			playerDetected = true;
		}
	}

	public void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player")) {
			playerDetected = false;
		}
	}
}
