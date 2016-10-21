using UnityEngine;
using System.Collections.Generic;
using System;

public class LevelManager : MonoBehaviour {

	[SerializeField]
	private ZombieController zombiePrefab;

	[HideInInspector]
	public ZombieController Zombie;

	[SerializeField]
	private LevelGenerator generator;

	private List<int> possibleDifficulties = new List<int>(){1};
	private int numberOfGeneratedSegments;
	private int xBound = 1;
	private float xBoundZombie = 10.5f;
	LevelSegment lastSegment;

	public static LevelManager Create () {
		return Instantiate (Resources.Load<LevelManager> ("Prefabs/Level Manager"));
	}

	public void CreateZombie () {
		Zombie = Instantiate (zombiePrefab);
		Zombie.transform.position = new Vector3 (1, 1, 10);
		Zombie.transform.SetParent (transform, false);
		GameManager.Instance.MenuManager.TouchController.PointerDown += Zombie.Jump;
		Camera.main.GetComponent<CameraFollow> ().Initialize (Zombie.transform);
	}

	public void Initialize () {
		GenerateStartingLevel();
	}

	// Update is called once per frame
	//listen to start new button
	void Update () {
		//chack if gaem is started
		//if() {generateStartingLevel(); }
		Debug.Log ("world pos " + transform.TransformPoint (lastSegment.EndPosition).x + " screee width" + Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height +
			"zombi" + Zombie.transform.position.x);
		if ( transform.TransformPoint(lastSegment.EndPosition).x - Camera.main.orthographicSize * 2.0 * Screen.width / Screen.height  <= xBound
			|| transform.TransformPoint(lastSegment.EndPosition).x - Zombie.transform.position.x <= xBoundZombie) {
			
			GenerateNextLevel();
		}
	}

	public void Reset()
	{
		numberOfGeneratedSegments = 0;
		possibleDifficulties.Clear();
	}

	private void GenerateStartingLevel(){
		// lana fake difficulty should be 0
		lastSegment = generator.generateSegment (1);
	}

	private void GenerateNextLevel(){
		System.Random rnd = new System.Random();
		int difficulty = rnd.Next(possibleDifficulties[0], possibleDifficulties[possibleDifficulties.Count -1] + 1);
		lastSegment = generator.generateSegment(difficulty);
		SetState ();
	}

	private void SetState(){
		numberOfGeneratedSegments++;

		if (numberOfGeneratedSegments % 5 == 0) {
			int largestDifficulty = possibleDifficulties [possibleDifficulties.Count - 1];
			if (possibleDifficulties.Count >= 3) {
				possibleDifficulties.RemoveAt (0);
			} else {
				possibleDifficulties.Add (largestDifficulty + 1);
			}
		}
	}
}
