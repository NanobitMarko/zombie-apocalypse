using UnityEngine;
using System.Collections;

public class LeaderboardMenu : BaseMenu {

	public int playerScore;

	public static LeaderboardMenu Create (int playerScore) {
		var menu = Instantiate (Resources.Load<LeaderboardMenu> ("Prefabs/LeaderboardMenu"));
		this.playerScore = playerScore;
		return menu;
	}

	private void Start () {
		GameManager.Instance.LeaderboardManager.IsGoodEnough (playerScore);
	}
}
