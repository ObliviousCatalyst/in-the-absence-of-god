using UnityEngine;
using UnityEngine.InputSystem;

public class input_handler : MonoBehaviour {
	public controller_V3 V3controller;
	InputAction moveAct, lookAct;

	void Start() {
		moveAct = InputSystem.actions.FindAction("Move");
		lookAct = InputSystem.actions.FindAction("Look");
		Cursor.visible = false;
	}

	void Update() {
		Vector2 movementVector = moveAct.ReadValue<Vector2>();
		V3controller.move(movementVector);
		Vector2 lookVector = lookAct.ReadValue<Vector2>();
		V3controller.rotate(lookVector);
	}
}
