﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
	[SerializeField]int currentSceneIndex;
	[SerializeField] int timeToWait = 4;
	// Use this for initialization
	void Start () {
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		if(currentSceneIndex == 0) {
			StartCoroutine(LoadStartMenu());
		}
	}
	IEnumerator LoadStartMenu() {
		yield return new WaitForSeconds(timeToWait);
		LoadNextScene();
	}
	public void LoadNextScene() {
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex + 1);
	}
	public void GameOver() {
		SceneManager.LoadScene("Start Screen");
	}
	public void RestartLevel() {
		Time.timeScale = 1;
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(currentSceneIndex);
	}
	public void LoadMainMenu() {
		Time.timeScale = 1;
		SceneManager.LoadScene("Start Screen");
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
	public void QuitGame() {
		Application.Quit();
	}
	public void LoadOptions() {
		SceneManager.LoadScene("Options");
		currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
	}
}
