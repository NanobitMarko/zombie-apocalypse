using UnityEngine;
using System.Collections.Generic;

public class LevelSegment : MonoBehaviour {

	[SerializeField]
	private Transform segmentStart;

	[SerializeField]
	private Transform segmentEnd;

	[SerializeField]
	private List<Transform> humanSpawnPoints;

	[SerializeField]
	private List<Transform> obstacleSpawnPoints;

	public Vector2 StartPosition {
		get { return segmentStart.position; }
	}

	public Vector2 EndPosition {
		get { return segmentEnd.position; }
	}
}
