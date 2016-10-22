using UnityEngine;
using System.Collections.Generic;

public class LeaderboardManager : MonoBehaviour {

	public int HighestPlayerScore = 0;

	public List<LeaderboardItem> items;

	public static LeaderboardManager Create () {
		return Instantiate (Resources.Load<LeaderboardManager> ("Prefabs/LeaderboardManager"));
	}

	public bool IsHighscore (int score) {
		return HighestPlayerScore <= score;
	}

	public void RecordPlayerScore (int score) {
		if (IsHighscore (score)) {
			HighestPlayerScore = score;
		}
	}
}

[System.Serializable]
public class LeaderboardItem {
	public string Name;
	public int Score;
}
