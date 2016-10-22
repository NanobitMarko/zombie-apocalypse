using UnityEngine;
using System.Collections;

public class GameOverMenu : BaseMenu {

	public static GameOverMenu Create () {
		return Instantiate (Resources.Load <GameOverMenu> ("Prefabs/GameOverMenu"));
	}

	public void OnRestartGameClicked () {
		GameManager.Instance.ShowMainScreen ();
		ExitMenu ();
	}

	public void OnLeaderboardsClicked () {
	}

	public void ExitMenu () {
		Destroy (gameObject);
	}

}
