using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ui_controller : MonoBehaviour {
	public string showing = "PDA";
	[SerializeField] Image PDA;
	[SerializeField] Image flash;
	[SerializeField] Image battery;
	[SerializeField] Image wrench;
	[SerializeField] Image hammer;
	[SerializeField] Image gas;

	[SerializeField] TextMeshProUGUI pdaDisplay;

	[SerializeField] monster_ctrl monsters;

	[SerializeField] inventory inven;

	public string pdaText = "default text";

	public bool 
	showText = false,
	showTime = false;

	void Update() {
		PDA.enabled = false; 
		pdaDisplay.enabled = false;
		flash.enabled = false;
		battery.enabled = false;
		wrench.enabled = false;
		hammer.enabled = false;
		gas.enabled = false;
		switch(showing) {
			case "PDA":
				PDA.enabled = true;
				if (showText) {
					pdaDisplay.enabled = true;
					string mins = math.floor(monsters.hardTime / 60).ToString();
					float secsNum = math.floor(monsters.hardTime % 60);
					string secs = secsNum.ToString();
					if (secsNum < 10) {
						secs = $"0{secs}"; 
					}
					string timer = "";
					if (showTime) {
						timer = $"{mins}:{secs}";	
					}
					pdaDisplay.text = $"{timer}\n{pdaText}";
				}
			break;

			case "flash":
				if (inven.flashes > 0) {
					flash.enabled = true;
				}
			break;

			case "battery":
				if (inven.batteries > 0) {
					battery.enabled = true;
				}
			break;

			case "wrench":
				if (inven.wrench) {
					wrench.enabled = true;
				}
				
			break;

			case "hammer":
				if (inven.hammer) {
					hammer.enabled = true;
				}
			break;

			case "gas":
				if (inven.gas) {
					gas.enabled = true;
				}
			break;
		}
	}

	public void show(string v) {
		showing = v;
	}

	public void write(string v) {
		showText = true;
		pdaText = v;
	}

	public void erase() {
		showText = false;
	}

	public void countdown() {
		showTime = true;
	}
}
