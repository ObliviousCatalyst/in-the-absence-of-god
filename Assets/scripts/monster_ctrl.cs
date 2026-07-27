using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class monster_ctrl : MonoBehaviour {
	class activityList {
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

	activityList active = new activityList(true);
	activityList attacking = new activityList(false);

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
	
	[SerializeField] Renderer angelRender;

	[SerializeField] trigger_detection angelTrigger;

	public float hardTime, angelInterval;

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
			float interval = angelInterval, timeIndex = 0;
			timeIndex += Time.deltaTime;
			int rand = UnityEngine.Random.Range(1,20);
			//Debug.Log($"{timeIndex >= interval} ~~ {rand == 1} ~~ {!attacking.angel}");
			if (timeIndex >= interval && rand == 1 && !attacking.angel) {
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

				StartCoroutine(timer(30f,() => {
					Debug.Log("timer expired");
					if (angelTrigger.playerDetected) {
						angelRender.enabled = true;
						Debug.Log("player is fucked");
						// do jumpscare and shit
					} 
					else {
						attacking.angel = false;
						angelT.position = transform.position;
						Debug.Log("player escaped");
					}
				}));

				Debug.Log("timer started");
			}
		} 

		if (active.wendigo) {
			
		}

		if (active.meatThing) {
			
		}
	}
}
