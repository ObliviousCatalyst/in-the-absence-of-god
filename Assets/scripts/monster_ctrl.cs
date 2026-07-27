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
	player,
	angel,
	wendigo,
	meatThing;
	

	void Start() {
		
	}

	void Update() {
		if (active.king) {
			
		}

		if (active.angel) {
			float interval = 5, timeIndex = 0;
			timeIndex += Time.deltaTime;
			if (timeIndex >= interval && UnityEngine.Random.Range(1,20) == 1 && !attacking.angel) {
				
			}
		} 

		if (active.wendigo) {
			
		}

		if (active.meatThing) {
			
		}
	}
}
