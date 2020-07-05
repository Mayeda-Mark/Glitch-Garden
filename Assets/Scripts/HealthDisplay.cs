using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {
	int playerHealth = 10;
	[SerializeField] int damage = 1;
	Text healthText;
	void Start () {
		healthText = GetComponent<Text>();
		SetHealthForDifficulty();
		UpdateDisplay();
	}
	private void SetHealthForDifficulty() {
		Debug.Log(PlayerPrefsController.GetMasterDifficulty());
		int difficultyFactor = (Mathf.RoundToInt(PlayerPrefsController.GetMasterDifficulty()* 5));
		Debug.Log(difficultyFactor);
		playerHealth -= difficultyFactor;
	}
	public int GetPlayerHealth() { return playerHealth; }
	private void UpdateDisplay() {
		healthText.text = playerHealth.ToString();
	}
	public void EnemyReachesBase() {
		playerHealth -= damage;
		UpdateDisplay();
		if(playerHealth <= 0) {
			FindObjectOfType<LevelController>().HandleLoss();
		}
	}
}