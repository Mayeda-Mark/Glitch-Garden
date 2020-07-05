using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour {
	[Range (0f, 5f)]
	float currentSpeed = 1f;
	GameObject currentTarget;
	Animator animator;
	private void Awake() {
		FindObjectOfType<LevelController>().AttackerSpawned();
	}
	void Update () {
		transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
		UpdateAnimiationState();
	}
	private void UpdateAnimiationState() {
		if(!currentTarget) {
			GetComponent<Animator>().SetBool("IsAttacking", false);
		}
	}
	public void SetMovementSpeed(float speed){
		currentSpeed = speed;
	}
	public void Attack(GameObject target) {
		GetComponent<Animator>().SetBool("IsAttacking", true);
		currentTarget = target;
	}
	public void StrikeCurrentTarget(float damage) {
		Debug.Log(damage);
		if(!currentTarget) { return; }
		Health health = currentTarget.GetComponent<Health>();
		if(health) {
			health.DealDamage(damage);
		}
	}
	private void OnDestroy() {
		LevelController levelController = FindObjectOfType<LevelController>();
		if(levelController != null) {
			levelController.AttackerKilled();
		}
	}
}