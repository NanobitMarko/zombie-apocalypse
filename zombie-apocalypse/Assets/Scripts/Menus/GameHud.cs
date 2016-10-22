using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameHud : BaseMenu {

	[SerializeField]
	private Image energy;

	public static GameHud Create () {
		return Instantiate (Resources.Load<GameHud> ("Prefabs/GameHud"));
	}

	private void Start () {
		GameManager.Instance.LevelManager.Zombie.State.EnergyChanged += OnZombieEnergyChanged;
	}

	private void OnZombieEnergyChanged (float current) {
		energy.fillAmount = current / ZombieState.MaxEnergy;
	}

	public void OnPauseClicked () {
		
	}
}
