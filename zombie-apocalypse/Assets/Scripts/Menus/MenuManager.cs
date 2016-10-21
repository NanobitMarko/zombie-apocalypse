using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	[SerializeField]
	private Canvas mainCanvas;

	[SerializeField]
	public LevelTouchController TouchController;

	public static MenuManager Create () {
		return Instantiate (Resources.Load<MenuManager> ("Prefabs/Main Canvas"));
	}

	public void ShowMenu (BaseMenu menu) {
		menu.transform.SetParent (mainCanvas.transform, false);
	}
}
