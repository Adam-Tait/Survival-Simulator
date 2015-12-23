using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Keybinds : MonoBehaviour {
	public Text forwardText;
	public Text leftText;
	public Text rightText;
	public Text backText;
	public Text jumpText;
	public Text sprintText;
	public Text useAndSwingText;
	public GameObject WarningText;
	public float WarningCooldown = 3.5f;
	
	//public string Label;
	public string pressedKey;
	public GameObject currentKey;
	public Event e;
	private string[] Commands;

	public Dictionary <string, KeyCode> Keybindings = new Dictionary<string, KeyCode> ();

	void Awake() {
		WarningText = GameObject.Find ("WarningText");
		forwardText = GameObject.Find ("ForwardButtonText").GetComponent<Text> ();
		leftText = GameObject.Find ("LeftButtonText").GetComponent<Text> ();
		rightText = GameObject.Find ("RightButtonText").GetComponent<Text> ();
		backText = GameObject.Find ("BackwardButtonText").GetComponent<Text> ();
		jumpText = GameObject.Find ("JumpButtonText").GetComponent<Text> ();
		sprintText = GameObject.Find ("SprintButtonText").GetComponent<Text> ();
		useAndSwingText = GameObject.Find ("UseAndSwingButtonText").GetComponent<Text> ();
	}

	void Start () {
		WarningText.SetActive (false);

		if (PlayerPrefs.HasKey ("Forward")) {
			Keybindings.Add ("Forward", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Forward")));
		} else {
			Keybindings.Add ("Forward", KeyCode.W);
		}
		if (PlayerPrefs.HasKey ("Left")) {
			Keybindings.Add ("Left", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Left")));
		} else {
			Keybindings.Add ("Left", KeyCode.A);
		}
		if (PlayerPrefs.HasKey ("Right")) {
			Keybindings.Add ("Right", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Right")));
		} else {
			Keybindings.Add ("Right", KeyCode.D);
		}
		if (PlayerPrefs.HasKey ("Back")) {
			Keybindings.Add ("Back", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Back")));
		} else {
			Keybindings.Add ("Back", KeyCode.S);
		}
		if (PlayerPrefs.HasKey ("Jump")) {
			Keybindings.Add ("Jump", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Jump")));
		} else {
			Keybindings.Add ("Jump", KeyCode.Space);
		}
		if (PlayerPrefs.HasKey ("Sprint")) {
			Keybindings.Add ("Sprint", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Sprint")));
		} else {
			Keybindings.Add ("Sprint", KeyCode.LeftShift);
		}
		if (PlayerPrefs.HasKey ("Swing")) {
			Keybindings.Add ("Swing", (KeyCode)System.Enum.Parse (typeof(KeyCode), PlayerPrefs.GetString("Swing")));
		} else {
			Keybindings.Add ("Swing", KeyCode.Mouse0);
		}


		forwardText.text = Keybindings ["Forward"].ToString ();
		leftText.text = Keybindings ["Left"].ToString ();
		rightText.text = Keybindings ["Right"].ToString ();
		backText.text = Keybindings ["Back"].ToString ();
		jumpText.text = Keybindings ["Jump"].ToString ();
		sprintText.text = Keybindings ["Sprint"].ToString ();
		useAndSwingText.text = Keybindings ["Swing"].ToString ();
	}

	void Update () {
		WarningCooldown -= Time.deltaTime;
		
		if (WarningCooldown < 0) {
			WarningCooldown = 0;
		}
		if (WarningCooldown == 0) {
			WarningText.SetActive(false);
		}
	}

	void OnGUI () {
		if (currentKey != null) {
			e = Event.current;
			if (e.isMouse) {
				switch (e.button) {
				case 0:
					if(Keybindings.ContainsValue(KeyCode.Mouse0)) {
						WarningText.SetActive(true);
						WarningCooldown = 3.5f;
						currentKey = null;
					}
					else {
					Keybindings [currentKey.name] = KeyCode.Mouse0;
					currentKey.transform.GetChild (0).GetComponent<Text> ().text = "Mouse0";
					currentKey = null;
					}
					break;
				case 1:
					if(Keybindings.ContainsValue(KeyCode.Mouse1)) {
						WarningText.SetActive(true);
						WarningCooldown = 3.5f;
						currentKey = null;
						break;
					}
					else {
					Keybindings [currentKey.name] = KeyCode.Mouse1;
					currentKey.transform.GetChild (0).GetComponent<Text> ().text = "Mouse1";
					currentKey = null;
					break;
					}
				}
			}
			else if (e.isKey) {
				if(Keybindings.ContainsValue(e.keyCode)) {
					WarningText.SetActive(true);
					WarningCooldown = 3.5f;
					currentKey = null;
				}
				else {
				Keybindings [currentKey.name] = e.keyCode;
				currentKey.transform.GetChild (0).GetComponent<Text> ().text = e.keyCode.ToString ();
				currentKey = null;
				}
			}
		}
	}



	public void ChangeKey(GameObject clicked) {
		currentKey = clicked;
	}

	public void ResetToDefault() {
		Keybindings.Remove ("Forward");
		Keybindings.Remove ("Left");
		Keybindings.Remove ("Right");
		Keybindings.Remove ("Back");
		Keybindings.Remove ("Jump");
		Keybindings.Remove ("Sprint");
		Keybindings.Remove ("Swing");

		Keybindings.Add ("Forward", KeyCode.W);
		Keybindings.Add ("Left", KeyCode.A);
		Keybindings.Add ("Right", KeyCode.D);
		Keybindings.Add ("Back", KeyCode.S);
		Keybindings.Add ("Jump", KeyCode.Space);
		Keybindings.Add ("Sprint", KeyCode.LeftShift);
		Keybindings.Add ("Swing", KeyCode.Mouse0);

		forwardText.text = Keybindings ["Forward"].ToString ();
		leftText.text = Keybindings ["Left"].ToString ();
		rightText.text = Keybindings ["Right"].ToString ();
		backText.text = Keybindings ["Back"].ToString ();
		jumpText.text = Keybindings ["Jump"].ToString ();
		sprintText.text = Keybindings ["Sprint"].ToString ();
		useAndSwingText.text = Keybindings ["Swing"].ToString ();
	}

}
