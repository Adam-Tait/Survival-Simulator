using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public GameObject mainSettingsMenu;
	public GameObject mainMenu;

	public void NewGame() {
		Application.LoadLevel ("Test Scene");
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void MainMenuSettings () {
		mainMenu.SetActive (false);
		mainSettingsMenu.SetActive (true);
	}
	
	public void EnableMenus() {
		mainMenu.SetActive (true);
		Time.timeScale = 1.0f;
	}

	public void FindSettings() {
		mainSettingsMenu = GameObject.Find ("SettingsMenu");
	}
}
