using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class intro : MonoBehaviour {
	[SerializeField] Renderer textRender;
	[SerializeField] Renderer logoRender;
	[SerializeField] AudioSource audio;
	bool started = false;

	void Start() {
		textRender.enabled = false;
		logoRender.enabled = false;
	}

	void Update() {
		IEnumerator waitAndExec (float seconds, System.Action callback) {
			yield return new WaitForSeconds(seconds);
			callback?.Invoke();
		}

		if (!audio.isPlaying & !started) {
			started = true;
			StartCoroutine(waitAndExec(0.5f, () => {
				textRender.enabled = true;
				StartCoroutine(waitAndExec(4,() => {
					textRender.enabled = false;
					StartCoroutine(waitAndExec(0.5f, () => {
						logoRender.enabled = true;
						StartCoroutine(waitAndExec(3,() => {
							SceneManager.LoadScene("forest");
						}));
					}));
				}));
			}));
		}
	}
}
