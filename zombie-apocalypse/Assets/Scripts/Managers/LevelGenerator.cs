using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour {

	float halfTileWidth = 0.64f;

	[SerializeField]
	private List<LevelSegment> segments;

	private Dictionary<int, List<LevelSegment>> segmentsForDifficulty;
	private HumanController[] humans;


	private LevelSegment currentSegment;

	public void Initialize() {
		humans = Resources.LoadAll<HumanController> ("Prefabs/Humans");

		segmentsForDifficulty = new Dictionary<int, List<LevelSegment>> ();
		foreach (var seg in segments) {
			List<LevelSegment> segs; 
			if (segmentsForDifficulty.ContainsKey (seg.Difficulty)) {
				segs = segmentsForDifficulty [seg.Difficulty];
			} else {
				segs = new List<LevelSegment> ();
				segmentsForDifficulty.Add (seg.Difficulty, segs);
			}
			segs.Add (seg);
		}
	}

	public LevelSegment generateSegment(int difficulty) {

		Vector3 mPos = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 10));

		Vector3 currentSegmentEnd = mPos + new Vector3(halfTileWidth, halfTileWidth, 0);
		if (currentSegment != null) {
			currentSegmentEnd = currentSegment.EndPosition;
		}

		LevelSegment toInstantiate = segmentsForDifficulty[difficulty] [(int)Random.Range (0, segmentsForDifficulty[difficulty].Count)];
		LevelSegment instantiated = Instantiate(toInstantiate, new Vector3(0,0,0), Quaternion.identity) as LevelSegment;

		// position new segment at the end of the old one
		Vector3 position =  toInstantiate.transform.position - (toInstantiate.StartPosition - currentSegmentEnd + new Vector3(halfTileWidth, 0, 0));
		position.y = currentSegmentEnd.y;
		instantiated.transform.position = position;
		instantiated.transform.SetParent (transform);


		currentSegment = instantiated;

		spawnHumans (currentSegment);

		return currentSegment;
	}

	void spawnHumans(LevelSegment segment) {

		foreach(var spawPoint in segment.humanSpawnPoints) {
			HumanController humanToInstantiate = humans [Random.Range (0, humans.Length)];
			HumanController human = Instantiate (humanToInstantiate) as HumanController;
			human.transform.SetParent (GameManager.Instance.LevelManager.transform);
			human.transform.position = spawPoint.position + new Vector3(0, human.GetComponentInChildren<SpriteRenderer> ().bounds.size.y / 2);
		}
	}

	void spawnObstacles(LevelSegment segment) {

	}
}
