using Unity.VisualScripting;
using UnityEngine;

public class interact_1 : MonoBehaviour {
	[SerializeField] inventory playerInvetory;
	[SerializeField] monster_ctrl monsters;
	[SerializeField] progresss_tracker_1 progress;
	[SerializeField] ui_controller UI;
	[SerializeField] string type;
	[SerializeField] string subtype;
	[SerializeField] int quantity;
	[SerializeField] string command;
	[SerializeField] Material active;
	bool usable = true;

	
	public void interact() {
		if (!usable) {
			return;	
		}
		switch (type) {
			case "give": 
				switch (subtype) {
					case "batteries":
						playerInvetory.batteries += quantity - playerInvetory.batteries;
						Debug.Log(playerInvetory.batteries.ToString());
						execute();
					break;	

					case "flashes":
						playerInvetory.flashes += quantity - playerInvetory.flashes;
						Debug.Log(playerInvetory.flashes.ToString());
						execute();
					break;

					case "gas":
						playerInvetory.gas = true;
						Debug.Log("aquired gas can");
						execute();
					break;
				}
			break;

			case "take":
				switch (subtype) {
					case "batteries":
						if (playerInvetory.batteries > 1 && UI.showing == "battery") {
							playerInvetory.batteries--;
							execute();
						}
					break;

					case "gas":
						if(playerInvetory.gas && UI.showing == "gas") {
							playerInvetory.gas = false;
							execute();
						}
					break;

					case "wrench":
						if(playerInvetory.wrench && UI.showing == "wrench") {
							playerInvetory.wrench = false;
							execute();
						}
					break;

					case "hammer":
						if(playerInvetory.hammer && UI.showing == "hammer") {
							playerInvetory.hammer = false;
							execute();
						}
					break;
				}
			break;

			case "interface":

			break;

			default:
				Debug.LogError("given interaction type does not exist");
			break;
		}
	}

	private void execute () {
		string[] cmd = command.Split(" ");
		int primeIndex = 0;

		void head (int index) {
			switch(cmd[index]) {
				case "wake":
					primeIndex++;
					wake(index + 1);
				break;

				case "complete":
					primeIndex++;
					complete(index +1);
				break;

				case "this":
					primeIndex++;
					alterThis(index + 1);
				break;

				case "fufill":
					primeIndex++;
					usable = false;
					Debug.Log("fufilled");
				break;
			}
			if (cmd[primeIndex] == ";") {
				primeIndex++;
				head(primeIndex);	
			}
		}

		void wake(int index) {
			switch(cmd[index]) {
				case "king":
					monsters.active.king = true;
				break;

				case "angel":
					monsters.active.angel = true;
				break;

				case "wendigo":
					monsters.active.wendigo = true;
				break;

				case "meat-thing":
					monsters.active.meatThing = true;
				break;
			}
			primeIndex++;
			if (cmd[index + 1] == ",") {
				primeIndex++;
				wake(index + 2);
			}
		}

		void complete (int index) {
			void major() {
				primeIndex++;
				switch(cmd[index]) {
					case "power":
						progress.power = true;
					break;

					case "radio":
						progress.radio = true;
					break;

					case "portal":
						progress.portal = true;
					break;
				}
			}

			void minor () {
				primeIndex++;
				Debug.Log("minor");
				progress.sensors++;
			}

			switch(cmd[index]) {
				case "major":
					primeIndex++;
					major();
				break;

				case "minor":
					primeIndex++;
					minor();
				break;
			}
		}

		void alterThis(int index) {
			if (cmd[index] == "color") {
				MeshRenderer mr = GetComponent<MeshRenderer>();
				Material[] mats = mr.materials;
				mats[0] = active;
				mr.materials = mats;
				Debug.Log("altered color");
			}
		}

		head(0);
	}
}
