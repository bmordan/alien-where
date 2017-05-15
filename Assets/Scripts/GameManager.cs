﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState {
	menu,
	inGame,
	gameOver
}

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	public GameState currentGameState;

	void Awake () {
		instance = this;
	}

	void Start () {
		currentGameState = GameState.menu;
	}

	void Update () {
		if (Input.GetButtonDown ("s"))
			StartGame ();
	}

	public void StartGame () {
		SetGameState (GameState.inGame);
	}
		
	public void GameOver () {
		SetGameState (GameState.gameOver);
	}

	public void BackToMenu () {
		SetGameState (GameState.menu);
	}

	void SetGameState (GameState newGameState) {
		if (newGameState == GameState.menu) {
		
		} else if (newGameState == GameState.inGame) {
		
		} else if (newGameState == GameState.gameOver) {
		
		}

		currentGameState = newGameState;
	}
}
