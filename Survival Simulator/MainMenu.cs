using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GameObject settingsCanvas;
	public GameObject mainMenuCanvas;

	public void NewGame () {
		Application.LoadLevelAdditive ("Test Scene");
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void OpenSettings () {
		mainMenuCanvas.SetActive (false);
		settingsCanvas.SetActive (true);
	}
}