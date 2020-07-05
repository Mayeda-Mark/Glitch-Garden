using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour {
	bool spawn = true;
	float minSpawnDelay = 3f;
	float maxSpawnDelay = 6f;
	[SerializeField] Attacker[] attackerPrefabs;
	IEnumerator Start () {
		SetSpawnDelay();
		while(spawn) {
			yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
			SpawnAttacker();
		}
	}
	private void SetSpawnDelay() {
		float difficultyFactor = (PlayerPrefsController.GetMasterDifficulty() * 2);
		minSpawnDelay -= difficultyFactor;
		maxSpawnDelay -= difficultyFactor;
	}
	private void SpawnAttacker() {
		int index = Random.Range(0, attackerPrefabs.Length);
		Spawn(attackerPrefabs[index]);
	}
	private void Spawn(Attacker attackerPrefab) {
		Attacker newAttacker = Instantiate(attackerPrefab, transform.position, transform.rotation) as Attacker;
		newAttacker.transform.parent = transform;
	}
	public void StopSpawning() {
		spawn = false;
	}
}
