using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour {
	[SerializeField] Defender defenderPrefab;
	private void Start() {
		CostButton();
	}
	private void CostButton() {
		Text costText = GetComponentInChildren<Text>();
		if(!costText) {
			Debug.LogError(name + " has no cost text!");
		} else {
			costText.text = defenderPrefab.GetStarCost().ToString();
		}
	}
	private void OnMouseDown() {
		var buttons = FindObjectsOfType<DefenderButton>();
		foreach(DefenderButton button in buttons) {
			button.GetComponent<SpriteRenderer>().color = new Color32(75, 75, 75, 255);
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		FindObjectOfType<PlaceDefender>().SetSelectedDefender(defenderPrefab);
	}
}
