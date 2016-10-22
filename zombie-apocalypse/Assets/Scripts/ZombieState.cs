using UnityEngine;
using System.Collections;

public class ZombieState {

	public float EnergyDrainPeriod = 0.4f;

	public static float MaxEnergy = 100.0f;

	private float energy = 100.0f;

	public float Energy {
		get { return energy; }
		set
		{
			energy = Mathf.Clamp (value, 0, MaxEnergy);
			if (EnergyChanged != null) {
				EnergyChanged (energy);
			}
		}
	}

	private float score = 0;

	public float Score {
		get { return score; }
		set
		{
			score = value;
			if (ScoreChanged != null) {
				ScoreChanged (score);
			}
		}
	}

	public delegate void EnergyChangedHandler (float currentValue);

	public event EnergyChangedHandler EnergyChanged;

	public delegate void ScoreChangedHandler (float currentValue);

	public event ScoreChangedHandler ScoreChanged;

	public void TickEnergy () {
		Energy -= 1;
	}
}
