using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece> ();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece> ();

	public void AddPiece() {
		int index;
		Vector3 spawnPosition;

		if (pieces.Count == 0) {
			index = 0;
			spawnPosition = levelStartPoint.position;
		} else {
			index = Random.Range(0, pieces.Count);
			spawnPosition = pieces[pieces.Count - 1].exitPoint.position;
		}

		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[index]);
		piece.transform.SetParent (this.transform, false);
		piece.transform.position = spawnPosition;
		pieces.Add(piece);
	}

	public void GenerateInitialPieces () {
		for (int i = 0; i < 2; i++) {
			AddPiece ();
		}
	}

	public void RemoveOldestPiece () {
		LevelPiece piece = pieces[0];
		pieces.Remove (piece);
		Destroy (piece.gameObject);
	}

	public void Reset () {
		pieces.ForEach (delegate (LevelPiece piece) {
			Destroy(piece.gameObject);
		});
		pieces.Clear ();
		GenerateInitialPieces ();
	}

	void Awake () {
		instance = this;
	}

	void Start () {
		GenerateInitialPieces ();
	}
		
}
