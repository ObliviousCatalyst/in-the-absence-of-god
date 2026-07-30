using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class startup : MonoBehaviour {
	[SerializeField] Button btn;
	public void Start () {
		btn.onClick.AddListener(() => {
			SceneManager.LoadScene("intro");
		});
	}
}
