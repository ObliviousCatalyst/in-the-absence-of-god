using UnityEngine;

public class trigger_detection : MonoBehaviour {
	public bool playerDetected = false;

	public void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Player")) {
			playerDetected = true;
			Debug.Log("player is in dager from angel");
		}
	}

	public void OnTriggerExit(Collider other) {
		if(other.CompareTag("Player")) {
			playerDetected = false;
			Debug.Log("player is clear from danger");
		}
	}
}
