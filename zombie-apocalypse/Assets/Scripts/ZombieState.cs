using UnityEngine;
using System.Collections;

public class ZombieState {

	public int EnergyDrainPeriod = 1;

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

	public delegate void EnergyChangedHandler (float currentValue);

	public event EnergyChangedHandler EnergyChanged;

	public void TickEnergy () {
		Energy -= 1;
	}
}
