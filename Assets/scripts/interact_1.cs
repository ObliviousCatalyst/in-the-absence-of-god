using Unity.VisualScripting;
using UnityEngine;

public class interact_1 : MonoBehaviour {
	[SerializeField] inventory playerInvetory;
	[SerializeField] string type;
	[SerializeField] string subtype;
	[SerializeField] int quantity;
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
	}
}
