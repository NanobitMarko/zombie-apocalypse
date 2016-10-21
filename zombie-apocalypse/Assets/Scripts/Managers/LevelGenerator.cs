using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	float halfTileWidth = 0.64f;

	[SerializeField]
	private List<LevelSegment> segments;

	private LevelSegment currentSegment;

	public LevelSegment generateSegment(int difficulty) {

		Vector3 mPos = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 10));

		Vector3 currentSegmentEnd = mPos + new Vector3(halfTileWidth, halfTileWidth, 0);
		if (currentSegment != null) {
			currentSegmentEnd = currentSegment.EndPosition;
		}

		LevelSegment toInstantiate = segments [(int)Random.Range (0, segments.Count)];
		currentSegment = Instantiate(toInstantiate, new Vector3(0,0,0), Quaternion.identity) as LevelSegment;

		// position new segment at the end of the old one
		Vector3 position =  currentSegmentEnd + (toInstantiate.StartPosition - currentSegment.EndPosition + new Vector3(halfTileWidth, 0, 0));
		currentSegment.transform.position = position;
		currentSegment.transform.SetParent (transform);

		return currentSegment;
	}
}
