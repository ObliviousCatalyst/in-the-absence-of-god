using Unity.Mathematics;
using UnityEngine;

public class controller_V3 : MonoBehaviour {
	public CharacterController controller;
	public float 
	moveSpd = 7f,
	rotSpd = 25,
	gravity = 30,
	maxRayDist = 30,
	stamina = 10,
	sprintBuffer = 0;
	public float rotX, rotY, vertVel, maxSpd;
	RaycastHit interRayData;
	public bool canSprint = true;

	void Start () {
		controller = GetComponent<CharacterController>();
	}

	void Update () {
		if (sprintBuffer < 0.5f) {
			moveSpd -= 7 * Time.deltaTime;
		}
		
		moveSpd = math.clamp(moveSpd,7,maxSpd);

		sprintBuffer -= Time.deltaTime;
		sprintBuffer = math.clamp(sprintBuffer,0,1);
		if (sprintBuffer == 0) {
			stamina += 3 * Time.deltaTime;
		}
		stamina = math.clamp(stamina,0,10);
		
		if (stamina > 7) {
			canSprint = true;
		}
		if (stamina == 0){
			canSprint = false;
		}
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
			if (interRayData.collider.TryGetComponent(out interact_1 objectFunc)) {
				objectFunc.interact();
			}
		}
	}

	public void sprint () {
		if(canSprint) {
			moveSpd += 3;
			stamina -= 1;
			sprintBuffer = 1;
		}
	}
}
