using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class input_handler : MonoBehaviour {
	public controller_V3 V3controller;
	InputAction moveAct, lookAct, interAct;

	void Start() {
		moveAct = InputSystem.actions.FindAction("Move");
		lookAct = InputSystem.actions.FindAction("Look");
		interAct = InputSystem.actions.FindAction("Interact");
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update() {
		Vector2 movementVector = moveAct.ReadValue<Vector2>();
		V3controller.move(movementVector);
		Vector2 lookVector = lookAct.ReadValue<Vector2>();
		Console.WriteLine(lookVector.ToString());
		V3controller.rotate(lookVector);
		bool playerInteract = interAct.ReadValue<bool>();
		V3controller.interact(playerInteract);
	}
}
