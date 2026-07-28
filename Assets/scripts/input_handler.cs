using System;
using UnityEngine;
using UnityEngine.InputSystem;


public class input_handler : MonoBehaviour {
	public controller_V3 V3controller;
	InputAction moveAct, lookAct, interAct, sprintAct, switchAct;
	[SerializeField] inventory playerInventory;

	void Start() {
		moveAct = InputSystem.actions.FindAction("Move");
		lookAct = InputSystem.actions.FindAction("Look");
		interAct = InputSystem.actions.FindAction("Interact");
		sprintAct = InputSystem.actions.FindAction("Sprint");
		switchAct = InputSystem.actions.FindAction("switch");
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		interAct.performed += ctx => {
			Debug.Log("interact performed");
			V3controller.interact();
		}; 
		sprintAct.performed += ctx => {
			V3controller.sprint();
		};
		switchAct.performed += (InputAction.CallbackContext context) => {
			if (context.control is UnityEngine.InputSystem.Controls.KeyControl key) {
				V3controller.switchItem((int)Char.GetNumericValue(key.name[0]));
			}
		};
		
	}

	void Update() {
		Vector2 movementVector = moveAct.ReadValue<Vector2>();
		V3controller.move(movementVector);
		Vector2 lookVector = lookAct.ReadValue<Vector2>();
		Console.WriteLine(lookVector.ToString());
		V3controller.rotate(lookVector);
	}
}
