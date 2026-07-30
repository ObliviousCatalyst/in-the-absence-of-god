using UnityEngine;
using UnityEngine.SceneManagement;

public class level_end : MonoBehaviour {
	[SerializeField] trigger_detection trigger;
	[SerializeField] Renderer render;
	[SerializeField] progresss_tracker_1 progress;

	void Start() {
		render.enabled = false;
	}

	void Update() {
		if (progress.portal) {
			render.enabled = true;
			if (trigger.playerDetected) {
				SceneManager.LoadScene("abrupt end");
			}
		}
	}
}
