using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector]
	public MenuManager MenuManager;

	[HideInInspector]
	public LevelManager LevelManager;

	[HideInInspector]
	public SoundManager SoundManager;

	[HideInInspector]
	public LeaderboardManager LeaderboardManager;

	public enum GameState {
		NOTSTARTED,
		STARTED,
		PAUSED,
		ENDED}

	;

	public GameState CurrentGameState;

	private void Start () {
		Initialize ();
	}

	private void Initialize () {
		if (Instance == null) {
			Instance = this;
		} else {
			Destroy (this.gameObject);
		}

		MenuManager = MenuManager.Create ();
		MenuManager.transform.SetParent (transform, false);
		LevelManager = LevelManager.Create ();
		LevelManager.Initialize ();
		LevelManager.transform.SetParent (transform, false);
		SoundManager = SoundManager.Create ();
		SoundManager.transform.SetParent (transform, false);
		LeaderboardManager = LeaderboardManager.Create ();
		LeaderboardManager.transform.SetParent (transform, false);

		CurrentGameState = GameState.NOTSTARTED;
		ShowMainScreen ();
	}

	public void ShowMainScreen () {
		MenuManager.ShowMenu (MainMenu.Create ());
	}

	public void StartGame () {
		CurrentGameState = GameState.STARTED;
		LevelManager.CreateZombie ();
		GameManager.Instance.MenuManager.ShowMenu (GameHud.Create ());
		SoundManager.PlaySoundEffect (SoundManager.Thunder);

		SoundManager.StartBackgroundMusicAtClipLength (6.0f);
	}

	public void PauseGame () {
		CurrentGameState = GameState.PAUSED;
		Time.timeScale = 0;
		MenuManager.ShowMenu (PauseMenu.Create ());
	}

	public void ResumeGame () {
		CurrentGameState = GameState.STARTED;
		Time.timeScale = 1;
	}

	public void EndGame () {
		CurrentGameState = GameState.ENDED;
		LevelManager.Reset ();
		MenuManager.ShowMenu (GameOverMenu.Create ());
	}

	public GameState GetCurrentGameState () {
		return this.CurrentGameState;
	}
}
