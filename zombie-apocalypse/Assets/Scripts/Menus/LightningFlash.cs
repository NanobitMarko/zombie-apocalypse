using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LightningFlash : BaseMenu {

	private const int FadeOutFrames = 60;

	[SerializeField]
	private Image lightning;

	[SerializeField]
	private Image whiteScreen;

	public static LightningFlash Create () {
		return Instantiate (Resources.Load<LightningFlash> ("Prefabs/LightningFlash"));
	}

	private void Start () {
		StartCoroutine (FadeOut ());
	}

	protected IEnumerator FadeOut () {
		for (int i = 1; i < FadeOutFrames + 1; i++) {
			yield return null;
			lightning.color = new Color (1, 1, 1, 1 - (float)i / (float)FadeOutFrames);
			whiteScreen.color = new Color (1, 1, 1, 1 - (float)(i % (FadeOutFrames / 2)) / (float)(FadeOutFrames / 2));
		}
		Destroy (gameObject);
	}
}
