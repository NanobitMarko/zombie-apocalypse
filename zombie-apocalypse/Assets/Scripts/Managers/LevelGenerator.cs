using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	[SerializeField]
	private List<LevelSegment> segments;

	private LevelSegment currentSegment;


	public void generateSegment(int difficulty, int humans) {

		Vector2 currentSegmentEnd = currentSegment.EndPosition;


		LevelSegment next = segments[(int) Random.Range(0, segments.Count)];

	
		Vector2 delta = next.StartPosition - currentSegment.EndPosition;

		next.transform.Translate (delta);
	}
}
