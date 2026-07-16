/****** PLEASE, OH PLAESE, DEAR GOD, DO NOT USE THIS PIECE OF SHIT UNLESS ABSOULTELY NECESARY ******/
using Mono.Cecil.Cil;
using UnityEngine;

public class controllerV2 : MonoBehaviour {
	public CharacterController controller;
	public float speedModifier = 5f;
	
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update() {
		Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
		controller.Move(movement * Time.deltaTime);
	}
}
