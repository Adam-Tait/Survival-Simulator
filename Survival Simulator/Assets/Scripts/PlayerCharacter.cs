using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	public float playerCurrentHealth;
	public int playerMaxHealth = 100;
	public float playerCurrentStamina;
	public int playerMaxStamina = 100;
	public float playerHealthRegeneration; //These will currently be hardcoded until perks are created.
	public float playerStaminaRegeneration;
	public float playerHunger;
	public float playerThirst;
	public string playerHungerState;
	public string playerThirstState;
	public float playerHungerRate = 0.33333f;
	public float playerThirstRate = 0.5f;
	
	void Start () { // May potentially need Awake () here instead if issues arise such as the player instantly dying.
		playerHealthRegeneration = playerMaxHealth * 0.002f;
		playerStaminaRegeneration = playerMaxStamina * 0.002f;
		playerCurrentHealth = playerMaxHealth;
		playerCurrentStamina = playerMaxStamina;
		playerHunger = 100;
		playerThirst = 100;
	}
	void Update () {
		if (playerHunger >= 100) {
			playerHunger = 100;
		}
		if (playerThirst >= 100) {
			playerThirst = 100;
		}

		//THIS IS BECAUSE OF UNITY BUG
		if (PauseScreen.isPaused) {
			playerHungerRate = 0;
			playerThirstRate = 0;
			playerStaminaRegeneration = 0;
			playerHealthRegeneration = 0;
		} else {
			playerHungerRate = 0.33333f;
			playerThirstRate = 0.5f;
			playerHealthRegeneration = playerMaxHealth * 0.002f;
			playerStaminaRegeneration = playerMaxStamina * 0.002f;
			playerHunger = playerHunger - playerHungerRate * Time.deltaTime;
			playerThirst = playerThirst - playerThirstRate * Time.deltaTime;

		}
		//THIS IS BECAUSE OF UNITY BUG


		PlayerNeeds ();
		// if statements are very inefficient, look at trying to fix them.
		if (playerCurrentHealth <= 0) {
			//You Die. (Kill character and trigger death screen.)
		} 
		else if (playerCurrentHealth > playerMaxHealth) {
			playerCurrentHealth = playerMaxHealth;
		} 
	if (playerCurrentStamina > playerMaxStamina) {
			playerCurrentStamina = playerMaxStamina;
		}
		else if (playerCurrentStamina < 0) {
			playerCurrentStamina = 0;
		}
	}

	void PlayerNeeds () {
		if (playerHunger < 0) {
			playerHunger = 0;
		}

		// Hunger

		if (playerHunger <= 100 && playerHunger > 50) {
			playerHungerState = "Satisfied";
		} 
		else if (playerHunger <= 50 && playerHunger > 20) {
			playerHungerState = "Hungry";
		} 
		else if (playerHunger <= 20 && playerHunger > 0) {
			playerHungerState = "Starving";
		} 
		else if (playerHunger == 0) {
			playerHungerState = "Dying(Hunger)";
		}

		// Thirst

		if (playerThirst < 0) {
			playerThirst = 0;
		}
		
		if (playerThirst <= 100 && playerThirst > 50) {
			playerThirstState = "Quenched";
		}
		else if (playerThirst <= 50 && playerThirst > 20) {
			playerThirstState = "Thirsty";
		} 
		else if (playerThirst <= 20 && playerThirst > 0) {
			playerThirstState = "Parched";
		} 
		else if (playerThirst == 0) {
			playerThirstState = "Dying(Thirst)";
		}

		//if statements to determine priority

		if (playerHungerState == "Satisfied" && playerThirstState == "Quenched") {
			playerCurrentHealth = playerCurrentHealth + playerHealthRegeneration * Time.deltaTime;
			playerCurrentStamina = playerCurrentStamina + playerStaminaRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Satisfied" && playerThirstState == "Thirsty") {
			playerCurrentHealth = playerCurrentHealth + playerHealthRegeneration * Time.deltaTime;
			playerCurrentStamina = playerCurrentStamina + playerStaminaRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Satisfied" && playerThirstState == "Parched") {
			playerCurrentStamina = playerCurrentStamina + playerStaminaRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Satisfied" && playerThirstState == "Dying(Thirst)") {
			playerCurrentHealth = playerCurrentHealth - 0.83333f * Time.deltaTime;
		}



		if (playerHungerState == "Hungry" && playerThirstState == "Quenched") {
			playerCurrentHealth = playerCurrentHealth + playerHealthRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Hungry" && playerThirstState == "Thirsty") {
			playerCurrentHealth = playerCurrentHealth + playerHealthRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Hungry" && playerThirstState == "Parched") {
			//No regen of health or stamina
		}
		if (playerHungerState == "Hungry" && playerThirstState == "Dying(Thirst)") {
			playerCurrentHealth = playerCurrentHealth - 0.83333f * Time.deltaTime;
		}



		if (playerHungerState == "Starving" && playerThirstState == "Quenched") {
			playerCurrentHealth = playerCurrentHealth + playerHealthRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Starving" && playerThirstState == "Thirsty") {
			playerCurrentHealth = playerCurrentHealth + playerHealthRegeneration * Time.deltaTime;
		}
		if (playerHungerState == "Starving" && playerThirstState == "Parched") {
			//No regen of health or stamina
		}
		if (playerHungerState == "Starving" && playerThirstState == "Dying(Thirst)") {
			playerCurrentHealth = playerCurrentHealth - 0.83333f * Time.deltaTime;
		}



		if (playerHungerState == "Dying(Hunger)" && playerThirstState == "Quenched") {
			playerCurrentHealth = playerCurrentHealth - 0.33333f * Time.deltaTime;
		}
		if (playerHungerState == "Dying(Hunger)" && playerThirstState == "Thirsty") {
			playerCurrentHealth = playerCurrentHealth - 0.33333f * Time.deltaTime;
		}
		if (playerHungerState == "Dying(Hunger)" && playerThirstState == "Parched") {
			playerCurrentHealth = playerCurrentHealth - 0.33333f * Time.deltaTime;
		}
		if (playerHungerState == "Dying(Hunger)" && playerThirstState == "Dying(Thirst)") {
			playerCurrentHealth = playerCurrentHealth - 1.16666f * Time.deltaTime;
		}
	}
}