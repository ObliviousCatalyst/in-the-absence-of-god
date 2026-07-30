using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class respawn : MonoBehaviour {
	[SerializeField] Button btn;
	void Start() {
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		btn.onClick.AddListener(() => {
			SceneManager.LoadScene("forest");
		});
	}
}
