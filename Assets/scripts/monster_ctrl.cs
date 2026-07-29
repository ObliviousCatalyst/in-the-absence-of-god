using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class monster_ctrl : MonoBehaviour {
	[System.Serializable]
	public class activityList {
		public bool 
		king,
		angel,
		wendigo,
		meatThing;
		public activityList(bool defaultVal) {
			this.king = defaultVal;
			this.angel = defaultVal;
			this.wendigo = defaultVal;
			this.meatThing = defaultVal;
		}
	}

	public activityList active = new activityList(false);
	public activityList attacking = new activityList(false);

	[SerializeField] Transform
	angelSpawn1, 
	angelSpawn2, 
	angelSpawn3, 
	angelSpawn4, 
	angelSpawn5,
	playerT,
	angelT,
	wendigoT,
	meatThingT;
	
	[SerializeField] Renderer angelRender, meatRender;

	[SerializeField] trigger_detection angelTrigger, meatTrigger;

	[SerializeField] NavMeshAgent meatThingAgent;

	public float 
	hardTime, 
	angelInterval, 
	angelForgiveness,
	meatInterval;

	[SerializeField] float angelTimeIndex = 0, meatTimeIndex = 0;

	void Start() {
		hardTime = 300;
		angelRender.enabled = false;
	}

	void Update() {
		if (active.king) {
			hardTime -= Time.deltaTime;
			if (hardTime <= 0) {
				// play jumpscare and kill player
			}
		}

		if (active.angel) {
			float interval = angelInterval;
			angelTimeIndex += Time.deltaTime;
			int rand = UnityEngine.Random.Range(1,20);
			//Debug.Log($"{timeIndex >= interval} ~~ {rand == 1} ~~ {!attacking.angel}");
			if (angelTimeIndex >= interval && rand == 1 && !attacking.angel) {
				Debug.Log("angel is attacking");
				attacking.angel = true;
				Transform[] transforms = new Transform[] {angelSpawn1,angelSpawn1,angelSpawn3,angelSpawn4,angelSpawn5};
				var minDist = Mathf.Infinity;
				Transform closest = angelSpawn1;
				foreach (Transform trans in transforms) {
					var tempDist = (trans.position - playerT.position).sqrMagnitude;
					if(tempDist < minDist) {
						minDist = tempDist;
						closest = trans;
					}
				}
				angelT.position = closest.position;

				IEnumerator timer (float delay, System.Action callback) {
					yield return new WaitForSeconds(delay);
					callback?.Invoke();
				}

				StartCoroutine(timer(angelForgiveness,() => {
					Debug.Log("timer expired");
					if (angelTrigger.playerDetected) {
						angelRender.enabled = true;
						Debug.Log("player is fucked");
						StartCoroutine(timer(10,() => SceneManager.LoadScene("death")));
						// do jumpscare and shit
					} 
					else {
						attacking.angel = false;
						angelT.position = transform.position;
						angelTimeIndex = 0;
						Debug.Log("player escaped");
					}
				}));

				Debug.Log("timer started");
			}
		} 

		if (active.wendigo) {
			
		}

		if (active.meatThing) {
			float interval = meatInterval;
			meatTimeIndex += Time.deltaTime;
			int rand = UnityEngine.Random.Range(1,20);
			if (meatTimeIndex >= interval && rand == 1 && !attacking.meatThing) {
				attacking.meatThing = true;
			}
			if (attacking.meatThing) {
				meatRender.enabled = true;
				meatTrigger.enabled = true;
				meatThingAgent.SetDestination(playerT.position);
				if (meatTrigger.playerDetected) {
					SceneManager.LoadScene("death");
				}
			}
			else {
				meatRender.enabled = false;
				meatTrigger.enabled = false;
			}
		}
		else {
			meatRender.enabled = false;
			meatTrigger.enabled = false;
		}	
	}
}
