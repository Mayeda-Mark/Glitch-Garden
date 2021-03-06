﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDefender : MonoBehaviour {
	Defender defenderPrefab;
	GameObject defenderParent;
	const string DEFENDER_PARENT_NAME = "Defenders";

	private void Start() {
		CreateDefenderParent();
	}
	private void CreateDefenderParent() {
		defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
		if(!defenderParent) {
			defenderParent = new GameObject(DEFENDER_PARENT_NAME);
		}
	}
	private void OnMouseDown() {
		AttemptToPlaceDefenderAt(GetSquareClicked());		
	}
	public void SetSelectedDefender(Defender selectedDefender) {
		defenderPrefab = selectedDefender;
	}
	private void AttemptToPlaceDefenderAt(Vector2 gridPos) {
		var starDisplay = FindObjectOfType<StarDisplay>();
		int defenderCost = defenderPrefab.GetStarCost();
		if(starDisplay.HaveEnoughStars(defenderCost)) {
			starDisplay.SpendStars(defenderCost);
			SpawnDefender(gridPos);
		}
	}
	private Vector2 GetSquareClicked() {
		Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
		return SnapToGrid(worldPos);
	}
	private Vector2 SnapToGrid(Vector2 rawWorldPos) {
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2(newX, newY);
	}
	private void SpawnDefender(Vector2 coordinates) {
		Defender newDefender = Instantiate(defenderPrefab, coordinates, Quaternion.identity) as Defender;
		newDefender.transform.parent = defenderParent.transform;
	}
}
