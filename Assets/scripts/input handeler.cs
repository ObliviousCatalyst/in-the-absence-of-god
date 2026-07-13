using UnityEngine;
using UnityEngine.InputSystem;

public class inputhandeler : MonoBehaviour
{
	public PlayerController CharacterController;
	private InputAction moveAction, lookAction;
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
	{
		moveAction = InputSystem.actions.FindAction("Move");
		lookActionAction = InputSystem.actions.FindAction("Look");
		
		Cursor.visible = false;
	}

	// Update is called once per frame
	void Update()
	{
		
	}
}
