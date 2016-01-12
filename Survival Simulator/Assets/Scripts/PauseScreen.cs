using UnityEngine;
using System.Collections;

public class PauseScreen : MonoBehaviour {

	public static bool isPaused;
	public bool resume;
	private GameObject camera;
	private CustomMouseLook mouseLook;
	private GameObject pauseMenu;
	private GameObject settingsMenu;
	private Keybinds Keybinds;

	void Awake () {
		camera = GameObject.Find ("Main Camera");
		mouseLook = camera.GetComponent <CustomMouseLook>();
		pauseMenu = GameObject.Find ("PauseMenu");
		settingsMenu = GameObject.Find ("SettingsMenu");
		Keybinds = GameObject.Find ("KeybindsManager").GetComponent<Keybinds> ();
	}

	void Start () {
		pauseMenu.SetActive (false);
		settingsMenu.SetActive (false);
		Time.timeScale = 1.0f;
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.Escape) && !isPaused) {
			Paused ();
		} 
		else if ((Input.GetKeyDown (KeyCode.Escape) && isPaused) || resume) {
			Resume ();
		}
	}

	void Paused () {
		//Time.timeScale = 0.0f; THIS IS A UNITY BUG
		mouseLook.enabled = false;
		isPaused = true;
		pauseMenu.SetActive (true);
		resume = false;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void MainMenu (int Scene) {
		Application.LoadLevel (Scene);
		isPaused = false;
	}

	public void Resume () {
		isPaused = false;
		pauseMenu.SetActive (false);
		Time.timeScale = 1.0f;
		mouseLook.enabled = true;
		resume = true;
		Cursor.visible = false;
		settingsMenu.SetActive (false);
		PlayerPrefs.SetString ("Forward", Keybinds.Keybindings ["Forward"].ToString ());
		PlayerPrefs.SetString ("Left", Keybinds.Keybindings ["Left"].ToString ());
		PlayerPrefs.SetString ("Right", Keybinds.Keybindings ["Right"].ToString ());
		PlayerPrefs.SetString ("Back", Keybinds.Keybindings ["Back"].ToString ());
		PlayerPrefs.SetString ("Jump", Keybinds.Keybindings ["Jump"].ToString ());
		PlayerPrefs.SetString ("Sprint", Keybinds.Keybindings ["Sprint"].ToString ());
		PlayerPrefs.SetString ("Swing", Keybinds.Keybindings ["Swing"].ToString ());
		PlayerPrefs.Save ();
	}

	public void OpenSettings() {
		settingsMenu.SetActive (true);
		pauseMenu.SetActive (false);
	}
}
