using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Settings : MonoBehaviour {
	public GameObject mainMenu;
	private GameObject mainSettingsMenu;
	public GameObject settingsMenu;
	private GameObject pauseMenu;
	private GameObject tab1;
	private GameObject tab2;
	private GameObject tab3;
	private GameObject tab4;
	private GameObject customSettingsManager;

	private Slider mouseSensitivity;
	private Slider fovSlider;
	private Text fovText;
	private Text msText;
	private Dropdown qualityDropdown;
	private Dropdown resolutionDropdown;
	private Toggle toggleFullscreen;
	private Toggle toggleVSync;
	private Text resolutionText;
	private Dropdown antiAliasing;
	private Dropdown textureQuality;

	public static float fov = 60;
	public string fovString = "";
	private string msSensitivityString = "";
	private bool fullscreen;

	void Awake () {
		mainMenu = GameObject.Find ("MainMenu");
		mainSettingsMenu = GameObject.Find ("MainMenuSettings");
		pauseMenu = GameObject.Find ("PauseMenu");
		tab1 = GameObject.Find ("Tab 1");
		tab2 = GameObject.Find ("Tab 2");
		tab3 = GameObject.Find ("Tab 3");
		tab4 = GameObject.Find ("Tab 4");
		mouseSensitivity = GameObject.Find("MouseSensitivity").GetComponent<Slider>();
		fovSlider = GameObject.Find ("FOV").GetComponent<Slider> ();
		fovText = GameObject.Find ("FOVOutputText").GetComponent<Text>();
		msText = GameObject.Find ("MouseSensitivityOutputText").GetComponent<Text> ();
		qualityDropdown = GameObject.Find ("QualityDropdown").GetComponent<Dropdown> ();
		resolutionDropdown = GameObject.Find ("ResolutionDropdown").GetComponent<Dropdown> ();
		toggleFullscreen = GameObject.Find ("ToggleFullscreen").GetComponent<Toggle> ();
		toggleVSync = GameObject.Find ("VSyncEnable").GetComponent<Toggle> ();
		customSettingsManager = GameObject.Find ("CustomSettingsManager");
		resolutionText = GameObject.Find ("ResolutionText").GetComponent<Text> ();
		antiAliasing = GameObject.Find ("AntiAliasing").GetComponent<Dropdown> ();
		textureQuality = GameObject.Find ("TextureQuality").GetComponent<Dropdown> ();

		fovSlider.value = fov;
		mouseSensitivity.value = CustomMouseLook.Xsensitivity;
		fovString = fov.ToString ();
		fovText.text = fovString;
		msSensitivityString = mouseSensitivity.value.ToString ();
		msText.text = msSensitivityString; 

	}
	
	void Start () {
		Tab1 ();
		mouseSensitivity.value = PlayerPrefs.GetFloat ("Sensitivity");
		ChangeSensitivity ();
		fovSlider.value = PlayerPrefs.GetFloat ("FOV");
		ChangeFOV ();
		qualityDropdown.value = PlayerPrefs.GetInt ("Quality");
		ChangeQuality ();
		resolutionDropdown.value = PlayerPrefs.GetInt ("Resolution");
		ChangeResolution ();
		antiAliasing.value = PlayerPrefs.GetInt ("AntiAliasing");
		AntiAliasing ();

		if (qualityDropdown.value == 4) {
			textureQuality.value = PlayerPrefs.GetInt ("TextureQuality");
			TextureQuality ();
		}
		
		if (PlayerPrefs.GetInt ("VSync") == 1) {
			toggleVSync.isOn = true;
			EnableVSync ();
		} else if (PlayerPrefs.GetInt ("VSync") == 0) {
			toggleVSync.isOn = false;
			EnableVSync ();
		}

		if (PlayerPrefs.GetInt ("Fullscreen") == 1) {
			toggleFullscreen.isOn = true;
			Fullscreen ();
		} else if (PlayerPrefs.GetInt ("Fullscreen") == 0) {
			toggleFullscreen.isOn = false;
			Fullscreen ();
		}
	}

	void Update () {
	}
	
	public void GoBackSettings () {
		settingsMenu.SetActive (false);
		pauseMenu.SetActive (true);
		PlayerPrefs.Save ();
	}

	public void GoBackToMainMenu() {
		mainSettingsMenu.SetActive (false);
		mainMenu.SetActive (true);
		PlayerPrefs.Save ();
	}

	public void Tab1 () {
		tab1.SetActive (true);
		tab2.SetActive (false);
		tab3.SetActive (false);
		tab4.SetActive (false);
	}

	public void Tab2 () { //Graphics
		tab1.SetActive (false);
		tab2.SetActive (true);
		tab3.SetActive (false);
		tab4.SetActive (false);
	}

	public void Tab3 () { //Audio
		tab1.SetActive (false);
		tab2.SetActive (false);
		tab3.SetActive (true);
		tab4.SetActive (false);
	}

	public void Tab4 () { //Keybinds
		tab1.SetActive (false);
		tab2.SetActive (false);
		tab3.SetActive (false);
		tab4.SetActive (true);
	}

	public void ChangeSensitivity() {
		CustomMouseLook.Xsensitivity = mouseSensitivity.value;
		msSensitivityString = mouseSensitivity.value.ToString ();
		msText.text = msSensitivityString;
		PlayerPrefs.SetFloat ("Sensitivity", mouseSensitivity.value);
	}

	public void ChangeFOV() {
		fov = fovSlider.value;
		fovString = fovSlider.value.ToString ();
		fovText.text = fovString;
		PlayerPrefs.SetFloat ("FOV", fovSlider.value);
	}

	public void Fullscreen() {
		if (toggleFullscreen.isOn) {
			fullscreen = true;
			Screen.fullScreen = true;
			PlayerPrefs.SetInt ("Fullscreen", 1);
		} 
		else {
			fullscreen = false;
			Screen.fullScreen = false;
			PlayerPrefs.SetInt ("Fullscreen", 0);
		}
	}                        

	public void ChangeQuality() {
		if (qualityDropdown.value == 0) {
			QualitySettings.SetQualityLevel (0);
			customSettingsManager.SetActive (false);
			QualitySettings.masterTextureLimit = 0;
			PlayerPrefs.SetInt ("Quality", qualityDropdown.value);
		} 
		else if (qualityDropdown.value == 1) {
			QualitySettings.SetQualityLevel (1);
			customSettingsManager.SetActive (false);
			QualitySettings.masterTextureLimit = 1;
			PlayerPrefs.SetInt ("Quality", qualityDropdown.value);
		} 
		else if (qualityDropdown.value == 2) {
			QualitySettings.SetQualityLevel (2);
			QualitySettings.masterTextureLimit = 3;
			customSettingsManager.SetActive (false);
			PlayerPrefs.SetInt ("Quality", qualityDropdown.value);
		} 
		else if (qualityDropdown.value == 3) {
			QualitySettings.SetQualityLevel (3);
			QualitySettings.masterTextureLimit = 4;
			customSettingsManager.SetActive (false);
			PlayerPrefs.SetInt ("Quality", qualityDropdown.value);
		} 
		else if (qualityDropdown.value == 4) {
			QualitySettings.SetQualityLevel (4);
			QualitySettings.masterTextureLimit = 0;
			customSettingsManager.SetActive (true);
			PlayerPrefs.SetInt ("Quality", qualityDropdown.value);
		}
	}

	public void ChangeResolution() {
		if (resolutionDropdown.value == 0) {
			Screen.SetResolution (2560, 1440, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		} 
		else if (resolutionDropdown.value == 1) {
			Screen.SetResolution (1920, 1080, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		}
		else if (resolutionDropdown.value == 2) {
			Screen.SetResolution (1600, 900, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		} 
		else if (resolutionDropdown.value == 3) {
			Screen.SetResolution (1366, 768, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		}
		else if (resolutionDropdown.value == 4) {
			Screen.SetResolution (1280, 720, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		} 
		else if (resolutionDropdown.value == 5) {
			Screen.SetResolution (1152, 648, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		} 
		else if (resolutionDropdown.value == 6) {
			Screen.SetResolution (1024, 576, fullscreen, 0);
			PlayerPrefs.SetInt ("Resolution", resolutionDropdown.value);
		} 
	}

	public void EnableVSync() {
		if (toggleVSync.isOn) {
			QualitySettings.vSyncCount = 1;
			PlayerPrefs.SetInt ("VSync", 1);
		} 
		else {
			QualitySettings.vSyncCount = 0;
			PlayerPrefs.SetInt ("VSync", 0);
		}
	}
	public void AntiAliasing() {
		if (antiAliasing.value == 0) {
			QualitySettings.antiAliasing = 8;
			PlayerPrefs.SetInt ("AntiAliasing", antiAliasing.value);
		} 
		else if (antiAliasing.value == 1) {
			QualitySettings.antiAliasing = 4;
			PlayerPrefs.SetInt ("AntiAliasing", antiAliasing.value);
		}
		else if (antiAliasing.value == 2) {
			QualitySettings.antiAliasing = 2;
			PlayerPrefs.SetInt ("AntiAliasing", antiAliasing.value);
		}
		else if (antiAliasing.value == 3) {
			QualitySettings.antiAliasing = 0;
			PlayerPrefs.SetInt ("AntiAliasing", antiAliasing.value);
		}
	}
	public void TextureQuality(){
		if (textureQuality.value == 0) {
			QualitySettings.masterTextureLimit = 0;
			PlayerPrefs.SetInt ("TextureQuality", textureQuality.value);
		} 
		else if (textureQuality.value == 1) {
			QualitySettings.masterTextureLimit = 1;
			PlayerPrefs.SetInt ("TextureQuality", textureQuality.value);
		}
		else if (textureQuality.value == 2) {
			QualitySettings.masterTextureLimit = 2;
			PlayerPrefs.SetInt ("TextureQuality", textureQuality.value);
		}
		else if (textureQuality.value == 3) {
			QualitySettings.masterTextureLimit = 3;
			PlayerPrefs.SetInt ("TextureQuality", textureQuality.value);
		}
	}
}
