using UnityEngine;
using System.Collections;

public class TabMenuControl : MonoBehaviour {

	private GameObject tabMenu;

	void Awake() {
		tabMenu = GameObject.Find ("TabMenu");
	}

	void Start () {
		tabMenu.SetActive (false);
	}

	void Update () {
		if (!PauseScreen.isPaused) {
			if (Input.GetKeyDown (KeyCode.Tab) && tabMenu.activeSelf == false) {
				tabMenu.SetActive (true);
			} else if (Input.GetKeyDown (KeyCode.Tab) && tabMenu.activeSelf == true) {
				tabMenu.SetActive (false);
			}
		}
		if (PauseScreen.isPaused && tabMenu.activeSelf == true) {
			tabMenu.SetActive(false);
		}
	}
}
