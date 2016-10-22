using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHud : BaseMenu {

	[SerializeField]
	private Image energy;

	[SerializeField]
	private Text score;

	public static GameHud Create () {
		return Instantiate (Resources.Load<GameHud> ("Prefabs/GameHud"));
	}

	private void Start () {
		GameManager.Instance.LevelManager.Zombie.State.EnergyChanged += OnZombieEnergyChanged;
		GameManager.Instance.LevelManager.Zombie.State.ScoreChanged += OnScoreChanged;
	}

	private void OnZombieEnergyChanged (float current) {
		energy.fillAmount = current / ZombieState.MaxEnergy;
	}

	private void OnScoreChanged (float current) {
		score.text = string.Format ("{0:n0}", current);
	}

	public void OnPauseClicked () {
		
	}
}
