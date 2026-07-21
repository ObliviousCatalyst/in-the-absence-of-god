using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller_V3 : MonoBehaviour {
	public CharacterController controller;
	public float moveSpd = 10f, rotSpd = 25;
	public float rotX, rotY;
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	public void move (Vector2 movementVector) {
		Vector3 movement = transform.forward * movementVector.y + transform.right * movementVector.x;
		movement = movement * moveSpd * Time.deltaTime;
		controller.Move(movement);
	}

	public void rotate (Vector2 lookVector) {
		Debug.Log(lookVector.ToString());
		// this is SUPPOSED to be negative. DO NOT CHANGE IT!
		rotX -= lookVector.y * rotSpd * Time.deltaTime;
		rotY += lookVector.x * rotSpd * Time.deltaTime;
		transform.localRotation = Quaternion.Euler(rotX,rotY,0);
	}

	public void interact (bool playerInteract) {
		if (playerInteract) {
			// do some shit
		}
	}
}
