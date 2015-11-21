using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour {

	private Slider masterVolumeSlider;
	private Slider backgroundMusicSlider;
	private AudioSource backgroundMusic;
	private AudioListener listener;

	private float masterVolumeDifference;

	void Awake () {
		masterVolumeSlider = GameObject.Find ("MasterVolume").GetComponent<Slider> ();
		backgroundMusicSlider = GameObject.Find ("MusicVolume").GetComponent<Slider> ();
		listener = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<AudioListener> ();
		backgroundMusic = GameObject.FindGameObjectWithTag ("BackgroundMusic").GetComponent<AudioSource> ();
	}

	void Start () {
		if (PlayerPrefs.GetFloat ("MasterVolume") == null) {
			AudioListener.volume = 1;
			masterVolumeSlider.value = 1;
		}
		if (PlayerPrefs.GetFloat ("MusicVolume") == null) {
			backgroundMusic.volume = 1;
			backgroundMusicSlider.value = 1;
		}

		AudioListener.volume = PlayerPrefs.GetFloat ("MasterVolume");
		masterVolumeSlider.value = PlayerPrefs.GetFloat ("MasterVolume");

		backgroundMusic.volume = PlayerPrefs.GetFloat ("MusicVolume");
		backgroundMusicSlider.value = PlayerPrefs.GetFloat ("MusicVolume"); 
	}

	public void ChangeMasterVolume() {
		AudioListener.volume = masterVolumeSlider.value;
		PlayerPrefs.SetFloat ("MasterVolume", masterVolumeSlider.value);
	}
	public void ChangeMusicVolume () {
		backgroundMusic.volume = backgroundMusicSlider.value;
		PlayerPrefs.SetFloat ("MusicVolume", backgroundMusicSlider.value);
	}
}
