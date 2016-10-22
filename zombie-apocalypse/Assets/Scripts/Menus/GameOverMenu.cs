using UnityEngine;
using System.Collections;

public class GameOverMenu : BaseMenu {

	public static GameOverMenu Create () {
		return Instantiate (Resources.Load <GameOverMenu> ("Prefabs/GameOverMenu"));
	}

	public void OnRestartGameClicked () {
		ExitMenu ();
		GameManager.Instance.StartGame ();
	}

	public void OnMainMenuClicked () {
		ExitMenu ();
		GameManager.Instance.ShowMainScreen ();
	}

	public void OnLeaderboardsClicked () {
	}

	public void ExitMenu () {
		Destroy (gameObject);
	}

}
