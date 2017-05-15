using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
	public static LevelGenerator instance;
	public List<LevelPiece> levelPrefabs = new List<LevelPiece> ();
	public Transform levelStartPoint;
	public List<LevelPiece> pieces = new List<LevelPiece> ();

	public void AddPiece() {

		//pick the random number
		int index = Random.Range(0, levelPrefabs.Count-1);

		//Instantiate copy of random level prefab and store it in piece variable
		LevelPiece piece = (LevelPiece)Instantiate(levelPrefabs[index]);
		piece.transform.SetParent(this.transform, false);

		Vector3 spawnPosition = Vector3.zero;

		//position
		if (pieces.Count == 0) {
			//first piece
			spawnPosition = levelStartPoint.position;
		}
		else {
			//take exit point from last piece as a spawn point to new piece
			spawnPosition = pieces[pieces.Count-1].exitPoint.position;
		}

		piece.transform.position = spawnPosition;
		pieces.Add(piece);
	}

	void Awake () {
		instance = this;
	}

	void Start () {
		AddPiece ();
		AddPiece ();
	}


}
