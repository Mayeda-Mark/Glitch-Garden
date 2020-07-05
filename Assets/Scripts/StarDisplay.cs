using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {
	int stars = 1000;
	Text starText;
	void Start () {
		starText = GetComponent<Text>();
		SetForDifficulty();
		UpdateDisplay();
	}
	private void SetForDifficulty() {
		int difficultyFactor = Mathf.RoundToInt(PlayerPrefsController.GetMasterDifficulty() * 200);
		stars -= difficultyFactor;
	}
	private void UpdateDisplay() {
		starText.text = stars.ToString();
	}
	public void AddStars(int amount) {
		stars += amount;
		UpdateDisplay();
	}
	public void SpendStars(int amount) {
		if(stars >= amount) {
			stars -= amount;
			UpdateDisplay();
		}
	}
	public bool HaveEnoughStars(int amount) {
		return stars >= amount;
	}
}
