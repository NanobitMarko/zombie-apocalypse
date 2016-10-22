using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	[SerializeField]
	AudioSource BGM_Player;

	[SerializeField]
	AudioSource SFX_Player;


	public const string BGMusic = "Sound/bg_music";

	public const string Thunder = "Sound/grmljavina_bolja";

	public const string ZombieDeath = "Sound/zombie_death";

	public const string ZombieKill = "Sound/zombie_jede_nekog";

	public static SoundManager Create () {
		return Instantiate (Resources.Load<SoundManager> ("Prefabs/SoundManager"));
	}

	public void StartBackgroundMusicAtClipLength (float clipLength) {
		BGM_Player.clip = Resources.Load<AudioClip> (BGMusic);
		BGM_Player.time = clipLength;
		BGM_Player.Play ();
	}

	public void PlaySoundEffect (string effect) {
		SFX_Player.clip = Resources.Load<AudioClip> (effect);
		SFX_Player.Play ();
	}
}
