using UnityEngine;
using System.Collections;

public class MainMenu : BaseMenu {

	public static MainMenu Create () {
		return Instantiate (Resources.Load <MainMenu> ("Prefabs/MainMenu"));
	}

	public void OnStartGameClicked () {
		GameManager.Instance.StartGame ();
		ExitMenu ();
	}

	public void OnLeaderboardsClicked () {
	}

	public void OnSettingsClicked () {
		
	}

	public void ExitMenu () {
		Destroy (gameObject);
	}

}
