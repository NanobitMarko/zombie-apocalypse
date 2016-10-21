using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager Instance;

	[HideInInspector]
	public MenuManager MenuManager;

	[SerializeField]
	public CharacterController zombie;

	private void Start () {
		Initialize ();
	}

	private void Initialize () {
		MenuManager = MenuManager.Create ();
		zombie.Initialize (MenuManager.TouchController);
	}

	public void StartGame () {
		
	}
}
