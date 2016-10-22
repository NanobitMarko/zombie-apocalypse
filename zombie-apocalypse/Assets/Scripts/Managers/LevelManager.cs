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

	private int maxDifficulty = 5;
	private List<int> possibleDifficulties = new List<int> (){ 1 };
	private int numberOfGeneratedSegments;
	private int xBound = 2;
	private float xBoundZombie = 30.5f;
	LevelSegment lastSegment;

	public static LevelManager Create () {
		return Instantiate (Resources.Load<LevelManager> ("Prefabs/Level Manager"));
	}

	public void CreateZombie () {
		Zombie = Instantiate (zombiePrefab);
		Zombie.transform.position = new Vector3 (1, 1, 0);
		Zombie.transform.SetParent (transform, false);
		GameManager.Instance.MenuManager.TouchController.PointerDown += Zombie.Jump;
		Camera.main.GetComponent<CameraController> ().Initialize (Zombie.transform);
		Zombie.DeathTriggered += OnZombieDied;
	}

	public void Initialize () {
		generator.Initialize ();
		GenerateStartingLevel ();
	}

	// Update is called once per frame
	//listen to start new button
	void Update () {
		if (GameManager.Instance.GetCurrentGameState() == GameManager.GameState.STARTED) {
			if (lastSegment.EndPosition.x - ScreenUtility.GetScreenSize () <= xBound
			   || lastSegment.EndPosition.x - Zombie.transform.position.x <= xBoundZombie) {			
				GenerateNextLevel ();
			}
		}
	}

	public void OnZombieDied (HumanoidController zombie) {
		Debug.Log ("MISSION ACCOMPLISHED.");
		GameManager.Instance.EndGame ();
	}

	public void Reset () {
		numberOfGeneratedSegments = 0;
		possibleDifficulties.Clear ();
		GenerateStartingLevel ();
	}

	private void GenerateStartingLevel () {
		// lana fake difficulty should be 0
		lastSegment = generator.generateSegment (1);
	}

	private void GenerateNextLevel () {
		System.Random rnd = new System.Random ();
		int difficulty = rnd.Next (possibleDifficulties [0], possibleDifficulties [possibleDifficulties.Count - 1] + 1);
		lastSegment = generator.generateSegment (difficulty);
		Debug.Log ("difficulty " + difficulty);
		SetState ();
	}

	private void SetState () {
		numberOfGeneratedSegments++;

		if (numberOfGeneratedSegments % 5 == 0) {
			int largestDifficulty = possibleDifficulties [possibleDifficulties.Count - 1];
			if (possibleDifficulties.Count >= 3) {
				possibleDifficulties.RemoveAt (0);
			} else {
				possibleDifficulties.Add (Math.Min(largestDifficulty + 1 , maxDifficulty));
			}
		}
		Debug.Log ( "generated segments " + numberOfGeneratedSegments);

		foreach( int poible in possibleDifficulties )
		{
			Debug.Log( "possibleDifficulties " + poible );
		}
	}
}
