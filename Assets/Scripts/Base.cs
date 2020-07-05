using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour {
	HealthDisplay healthDisplay;
	LevelLoader levelLoader;
	void Start() {
		healthDisplay = FindObjectOfType<HealthDisplay>();
		levelLoader = FindObjectOfType<LevelLoader>();
	}
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		GameObject otherObject = otherCollider.gameObject;
		if(otherObject.GetComponent<Attacker>()) {
			healthDisplay.EnemyReachesBase();
			Destroy(otherObject);
		}
	}
}
