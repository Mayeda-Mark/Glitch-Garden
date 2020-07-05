using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
	[SerializeField] float speed = 2f;
	[SerializeField] float damage = 50f;
	[SerializeField] float spinRate = 150f;
	// Use this for initialization
	void Start () {
	}
	void Update () {
		transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
		transform.Rotate(0, 0, spinRate *Time.deltaTime);
	}
	private void OnTriggerEnter2D(Collider2D otherCollider) {
		var health = otherCollider.GetComponent<Health>();
		var attacker = otherCollider.GetComponent<Attacker>();
		if(attacker && health) {
			health.DealDamage(damage);
			Destroy(gameObject);
		}
	}
}
