using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
[SerializeField] float health = 100f;
	[SerializeField] GameObject explosion;
	[SerializeField] float durationOfExplosion = 1f;
	public void DealDamage(float damage) {
		health -= damage;
		if( health <= 0) {
			Kill();
		}
	}
	public void Kill() {
		TriggerVFX();
		Destroy(gameObject);
	}
	private void TriggerVFX() {
		if (! explosion) { return; 
		
		}
		GameObject explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
		Destroy(explosionVFX, durationOfExplosion);
	}
}
