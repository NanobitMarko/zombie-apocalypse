using UnityEngine;
using System.Collections;

public class ZombieState {

	public int EnergyDrainPeriod = 1;

	public static int MaxEnergy = 100;

	private int energy = 100;

	public int Energy {
		get { return energy; }
		set
		{
			energy = value; 
			if (EnergyChanged != null) {
				EnergyChanged (energy);
			}
		}
	}

	public delegate void EnergyChangedHandler (int currentValue);

	public event EnergyChangedHandler EnergyChanged;

	public void TickEnergy () {
		Energy -= 1;
	}
}
