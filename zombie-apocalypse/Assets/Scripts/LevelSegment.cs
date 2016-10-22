using UnityEngine;
using System.Collections.Generic;

public class LevelSegment : MonoBehaviour {

	public int Difficulty;

	[SerializeField]
	private Transform segmentStart;

	[SerializeField]
	private Transform segmentEnd;

	[SerializeField]
	public List<Transform> humanSpawnPoints;

	[SerializeField]
	public List<Transform> obstacleSpawnPoints;

	public Vector3 StartPosition {
		get { return segmentStart.position; }
	}

	public Vector3 EndPosition {
		get { return segmentEnd.position; }
	}

	void Update () {
		if (ScreenUtility.IsLeftOfScreen (EndPosition)) {
			Destroy (gameObject);
		}
	}
}
