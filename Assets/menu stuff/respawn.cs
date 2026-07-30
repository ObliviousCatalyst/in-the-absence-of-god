using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class respawn : MonoBehaviour {
	[SerializeField] Button btn;
	void Start() {
		btn.onClick.AddListener(() => {
			SceneManager.LoadScene("forest");
		});
	}
}
