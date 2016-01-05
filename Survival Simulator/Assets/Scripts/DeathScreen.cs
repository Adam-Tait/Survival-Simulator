using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour {

	public void MainMenu () {
		SceneManager.LoadScene (0);
	}

	public void StartOver() {
		SceneManager.LoadScene (1);
	}
}
