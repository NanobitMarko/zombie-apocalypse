using UnityEngine;
using System.Collections;

public class SettingsMenu : BaseMenu {

	public static SettingsMenu Create () {
		return Instantiate (Resources.Load <SettingsMenu> ("Prefabs/SettingsMenu"));
	}

	public void OnMusicClicked () {
		GameManager.Instance.SoundManager.SetBackgroundMusicActive ();
	}

	public void OnSoundsClicked () {
		GameManager.Instance.SoundManager.SetSoundEffectsActive ();
	}

	public void OnExitClicked () {
		ExitMenu ();
	}

	public void ExitMenu () {
		Destroy (gameObject);
	}

}
