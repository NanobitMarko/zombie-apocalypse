using UnityEngine;
using System.Collections.Generic;

public class LevelSegment : MonoBehaviour {

	public int Difficulty;

	[SerializeField]
	private Transform segmentStart;

	[SerializeField]
	private Transform segmentEnd;

	[SerializeField]
	private List<Transform> humanSpawnPoints;

	[SerializeField]
	private List<Transform> obstacleSpawnPoints;

	public Vector3 StartPosition {
		get { return segmentStart.position; }
	}

	public Vector3 EndPosition {
		get { return segmentEnd.position; }
	}
}
