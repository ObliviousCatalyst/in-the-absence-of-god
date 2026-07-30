using System;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class audioplayer : MonoBehaviour {
	public bool play1 = true, play2 = false, overPlay = false;
	[SerializeField] trigger_detection angelTrigger; 
	[SerializeField] AudioSource aud1, aud2, aud3;
	[SerializeField] monster_ctrl monsters;


	void Start() {
		aud1 = GetComponent<AudioSource>();
	}

	void Update() {
		if (monsters.hardTime < 60) {
			play2 = true;
		}
		
		if (angelTrigger.playerDetected || overPlay || play2) {
			play1 = false;
		}
		else {
			play1 = true;
		}

		if (overPlay && !aud3.isPlaying) {
			aud3.volume = 1;
			aud3.Play();	
		}

		if (play1) {
			if(!aud1.isPlaying) {
				aud1.Play();
			}
			aud1.volume += Time.deltaTime;
		}
		else {
			aud1.volume -= Time.deltaTime;
		}

		if (play2) {
			if (!aud2.isPlaying) {
				aud2.Play();
			}
			aud2.volume += Time.deltaTime;
		}
		aud1.volume = math.clamp(aud1.volume, 0, 1);
	}
}
