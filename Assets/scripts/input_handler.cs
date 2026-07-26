using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class input_handler : MonoBehaviour {
	public controller_V3 V3controller;
	InputAction moveAct, lookAct, interAct, sprintAct;
	float bufferTime;
	float bufferTimeConst = 0.05f;
	inventory playerInventory = new inventory();

	void Start() {
		moveAct = InputSystem.actions.FindAction("Move");
		lookAct = InputSystem.actions.FindAction("Look");
		interAct = InputSystem.actions.FindAction("Interact");
		sprintAct = InputSystem.actions.FindAction("Sprint");
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		interAct.performed += ctx => {
			Debug.Log("interact performed");
			V3controller.interact();
			// the lines below is TEMPORARY
			inventory.item temp = new inventory.item("a");
			playerInventory.unlimited.add(0,temp);
		}; 
		sprintAct.performed += ctx => {
			bufferTime += bufferTimeConst;
		};
		
	}

	void Update() {
		Vector2 movementVector = moveAct.ReadValue<Vector2>();
		V3controller.move(movementVector);
		Vector2 lookVector = lookAct.ReadValue<Vector2>();
		Console.WriteLine(lookVector.ToString());
		V3controller.rotate(lookVector);
		if (bufferTime > 0) {
			bufferTime -=  Time.deltaTime;
		}
		V3controller.sprint(bufferTime > 0);
		
	}
}
