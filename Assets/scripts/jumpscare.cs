using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class jumpscare : MonoBehaviour {
	[SerializeField] Image
	king,
	angel,
	meat;

	[SerializeField] RectTransform 
	kingTrans,
	angelTrans,
	meatTrans;

	[SerializeField] AudioSource screamer;

	Vector3 kingPosCache, angelPosCache, meatPosCache;
	
	void Start() {
		king.enabled = false;
		angel.enabled = false;
		meat.enabled = false;
		kingPosCache = kingTrans.position;
		angelPosCache = angelTrans.position;
		meatPosCache = meatTrans.position;
	}

	void Update() {
		kingTrans.position = animate(kingPosCache);
		angelTrans.position = animate(angelPosCache);
		meatTrans.position = animate(meatPosCache);
	}

	public void kingScare () {
		king.enabled = true;
		screamer.Play();
		waitAndExec(3,() => SceneManager.LoadScene("death"));
	}

	public void angelScare () {
		angel.enabled = true;
		screamer.Play();
		waitAndExec(3,() => SceneManager.LoadScene("death"));
	}

	public void meatScare () {
		meat.enabled = true;
		screamer.Play();
		waitAndExec(3,() => SceneManager.LoadScene("death"));
	}

	void waitAndExec(float sec, System.Action callback) {
		IEnumerator waitEnumerator () {
			yield return new WaitForSeconds(sec);
			callback?.Invoke();
		}
		StartCoroutine(waitEnumerator());
	}

	Vector3 animate (Vector3 center) {
		return new Vector3(UnityEngine.Random.Range(center.x - 20, center.x + 20),UnityEngine.Random.Range(center.y - 20,center.y + 20),0);
	}
}
