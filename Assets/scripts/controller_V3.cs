using System;
using System.Text.Json.Serialization;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class controller_V3 : MonoBehaviour {
	public CharacterController controller;
	public float moveSpd = 10f, rotSpd = 25, gravity = 30, maxRayDist = 30;
	public float rotX, rotY, vertVel;
	RaycastHit interRayData;
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	public void move (Vector2 movementVector) {
		Vector3 movement = transform.forward * movementVector.y + transform.right * movementVector.x;
		movement = movement * moveSpd * Time.deltaTime;
		controller.Move(movement);
		vertVel -= gravity * Time.deltaTime;
		controller.Move(new Vector3(0,vertVel,0) * Time.deltaTime);
	}

	public void rotate (Vector2 lookVector) {
		//Debug.Log(lookVector.ToString());
		// this is SUPPOSED to be negative. DO NOT CHANGE IT!
		rotX -= lookVector.y * rotSpd * Time.deltaTime;
		rotY += lookVector.x * rotSpd * Time.deltaTime;
		rotX = math.clamp(rotX,-90,90);
		transform.localRotation = Quaternion.Euler(rotX,rotY,0);
	}

	public void interact () {
		Debug.Log("interaction function called");
		if (Physics.Raycast(transform.position,transform.forward,out interRayData,maxRayDist)) {
			Debug.Log("fired raycast");
			Debug.Log($"raycast return: { interRayData.collider.name }");
		}
	}
}
