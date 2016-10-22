using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverMenu : BaseMenu {

	public Text Score;

	public static GameOverMenu Create () {
		return Instantiate (Resources.Load <GameOverMenu> ("Prefabs/GameOverMenu"));
	}

	public void Start (){
		Score.text = string.Format("{0:N0}", GameManager.Instance.LevelManager.Zombie.State.Score);
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
