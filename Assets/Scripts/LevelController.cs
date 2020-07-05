using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {
	[SerializeField] GameObject winLabel;
	[SerializeField] int winDelay = 5;
	[SerializeField] AudioSource winSound;
	[SerializeField] GameObject loseLabel;
	[SerializeField] int loseDelay = 5;
	[SerializeField] AudioSource loseSound;
	GameTimer gameTimer;
	[SerializeField] int numberOfAttackers = 0;
	bool levelTimerFinished = false;
	private void Start() {
		winLabel.SetActive(false);
		loseLabel.SetActive(false);
	}
	public void AttackerSpawned() {
		numberOfAttackers ++;
	}
	public void AttackerKilled() {
		numberOfAttackers --;
		if(numberOfAttackers <= 0 && levelTimerFinished) {
			StartCoroutine(HandleWinCondition());
		}
	}
	IEnumerator HandleWinCondition() {
		yield return new WaitForSeconds(winDelay);
		winSound.Play();
		winLabel.SetActive(true);
		StartCoroutine(NextLevel());
	}
	IEnumerator NextLevel() {
	var loader = FindObjectOfType<LevelLoader>();
	yield return new WaitForSeconds(5);
	loader.LoadNextScene();
	}
	public void HandleLoss(){
		loseLabel.SetActive(true);
		Time.timeScale = 0;
	}
	public void OutOfTIme() {
		levelTimerFinished = true;
		StopSpawners();
	}
	private void StopSpawners() {
		AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();
		foreach(AttackerSpawner spawner in spawners) {
			spawner.StopSpawning();
		}
	}
}
