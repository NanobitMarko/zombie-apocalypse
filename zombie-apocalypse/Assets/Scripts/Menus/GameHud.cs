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

	private void OnZombieEnergyChanged (int current) {
		energy.fillAmount = (float)current / (float)ZombieState.MaxEnergy;
	}

	public void OnPauseClicked () {
		
	}
}
