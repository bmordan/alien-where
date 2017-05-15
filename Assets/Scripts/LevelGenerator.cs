using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece> ();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece> ();

	public void AddPiece() {
		int randomIndex = Random.Range(0, levelPrefabs.Count);
		Vector3 spawnPosition = Vector3.zero;
		LevelPiece piece;

		if (pieces.Count == 0) {
			piece = (LevelPiece)Instantiate(levelPrefabs[0]);
			spawnPosition = levelStartPoint.position;
		}
		else {
			spawnPosition = pieces[pieces.Count-1].exitPoint.position;
			piece = (LevelPiece)Instantiate(levelPrefabs[randomIndex]);
		}

		piece.transform.SetParent(this.transform, false);
		piece.transform.position = spawnPosition;
		pieces.Add(piece);
	}

	public void GenerateInitialPieces () {
		for (int i = 0; i < 2; i++) {
			AddPiece ();
		}
	}

	public void RemoveOldestPiece () {
		LevelPiece oldestPiece = pieces[0];
		pieces.Remove (oldestPiece);
		Destroy (oldestPiece.gameObject);
	}

	void Awake () {
		instance = this;
	}

	void Start () {
		GenerateInitialPieces ();
	}
		
}
