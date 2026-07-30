using Unity.VisualScripting;
using UnityEngine;

public class progresss_tracker_1 : MonoBehaviour {
	public bool power = false;
	public bool radio = false;
	public bool portal = false;
	public int sensors = 0;

	[SerializeField] ui_controller UI;

	void Update() {
		if (!power) {
			UI.write("turn on the power");
		}
		else {
			UI.showTime = true;
		}
		string uiText;
		string uit1 = "";
		string uit2 = "";
		if (power && !radio) {
			uit1 = "repair the radio tower.";
		}

		if (power && sensors < 7) {
			uit2 = "replace sensor batteries.";
		}

		if (power && (!radio || sensors < 7)) {
			uiText = $"{uit1}\n{uit2}";
			UI.write(uiText);
		}

		if (radio && sensors >= 7 && !portal) {
			UI.write("jam the hammer into the power box in the cabin");
		}

		if(portal) {
			UI.write("go thorugh the portal");
		}
	}
}
