using UnityEngine;
using System.Collections;

public class PauseMenu : BaseMenu {

	public static PauseMenu Create () {
		return Instantiate (Resources.Load <PauseMenu> ("Prefabs/PauseMenu"));
	}

	public void OnResumeGameClicked () {
		ExitMenu ();
		GameManager.Instance.ResumeGame ();
	}

	public void OnMainMenuClicked () {
		ExitMenu ();
		GameManager.Instance.ShowMainScreen ();
	}

	public void OnSettingsClicked () {

	}

	public void ExitMenu () {
		Destroy (gameObject);
	}

}

