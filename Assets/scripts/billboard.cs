using UnityEngine;
public class billboard : MonoBehaviour {
	Transform cameraTrans;
	void Start() {
		cameraTrans = Camera.main.transform;
	}

	void Update(){
		transform.LookAt(cameraTrans);
	}
}
