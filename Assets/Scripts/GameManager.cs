﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum GameState {
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public GameState currentGameState = GameState.menu;
	public Canvas menuCanvas;
	public Canvas inGameCanvas;
	public Canvas gameOver;


	void Awake() {
		instance = this;
	}

	void Start() {
		currentGameState = GameState.menu;
	}

	public void ReStartGame () {
		LevelGenerator.instance.Reset();
		StartGame ();
	}
		
	public void StartGame() {
		CameraFollow.instance.ResetToStartPosition ();
		PlayerController.instance.StartGame ();
		SetGameState(GameState.inGame);
	}

	public void GameOver() {
		SetGameState(GameState.gameOver);
	}
		
	public void BackToMenu() {
		CameraFollow.instance.ResetToStartPosition ();
		LevelGenerator.instance.Reset();
		SetGameState(GameState.menu);
	}

	void SetGameState (GameState newGameState) {

		if (newGameState == GameState.menu) {
			menuCanvas.enabled = true;
			inGameCanvas.enabled = false;
			gameOver.enabled = false;
		}
		else if (newGameState == GameState.inGame) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = true;
			gameOver.enabled = false;
		}
		else if (newGameState == GameState.gameOver) {
			menuCanvas.enabled = false;
			inGameCanvas.enabled = false;
			gameOver.enabled = true;
		}

		currentGameState = newGameState;
	}
}