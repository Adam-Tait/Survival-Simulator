using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {
	private Slider healthSlider;
	private Slider staminaSlider;
	private Slider hungerSlider;
	private Slider thirstSlider;
	private PlayerCharacter playerCharacter;

 	void Awake () {
		healthSlider = GameObject.Find ("Health").GetComponent<Slider> ();
		staminaSlider = GameObject.Find ("Stamina").GetComponent<Slider> ();
		hungerSlider = GameObject.Find ("Hunger").GetComponent<Slider> ();
		thirstSlider = GameObject.Find ("Thirst").GetComponent<Slider> ();
		playerCharacter = GameObject.Find ("Player").GetComponent<PlayerCharacter>();
	}

	void Update() {
		healthSlider.value = playerCharacter.playerCurrentHealth;
		staminaSlider.value = playerCharacter.playerCurrentStamina;
		hungerSlider.value = playerCharacter.playerHunger;
		thirstSlider.value = playerCharacter.playerThirst;
	}
}
