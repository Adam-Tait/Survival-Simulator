using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class SongPlaylist : MonoBehaviour {

	public AudioClip[] songs; //assign through inspector
	public int songNumber = 0;

	private AudioClip audio;
	private AudioSource audioSource;

	void Awake () {
		audioSource = GameObject.Find ("BackgroundMusic").GetComponent<AudioSource> ();
		audio = GameObject.Find ("BackgroundMusic").GetComponent<AudioClip> ();
	}

	void Update () {
		StartAudio ();
	}
	
	void StartAudio() {
		if (audioSource.isPlaying == false) {
			songNumber++;

			if (songNumber >= songs.Length) {
				songNumber = 0;
				audio = songs[songNumber];
				audioSource.clip = audio;
				audioSource.Play ();
			}
			else {
				audio = songs[songNumber];
				audioSource.clip = audio;
				audioSource.Play ();
			}
		}
	}
}
