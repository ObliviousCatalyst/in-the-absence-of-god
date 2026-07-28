using Unity.VisualScripting;
using UnityEngine;

public class interact_1 : MonoBehaviour {
	[SerializeField] inventory playerInvetory;
	[SerializeField] monster_ctrl monsters;
	[SerializeField] string type;
	[SerializeField] string subtype;
	[SerializeField] int quantity;
	[SerializeField] string command;

	
	public void interact() {
		switch (type) {
			case "give": 
				switch (subtype) {
					case "batteries":
						playerInvetory.batteries += quantity - playerInvetory.batteries;
						Debug.Log(playerInvetory.batteries.ToString());
					break;	

					case "flashes":
						playerInvetory.flashes += quantity - playerInvetory.flashes;
						Debug.Log(playerInvetory.flashes.ToString());
					break;
				}
			break;

			case "take":

			break;

			case "interface":

			break;

			default:
				Debug.LogError("given interaction type does not exist");
			break;
		}
		if (command != "") {
			execute();
		}
	}

	private void execute () {
		string[] cmd = command.Split(" ");
		int primeIndex = 0;
		void head (int index) {
			switch(cmd[index]) {
				case "wake":
					primeIndex++;
					wake(1);
				break;

				case "complete":
					primeIndex++;
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
		head(0);
	}
}
