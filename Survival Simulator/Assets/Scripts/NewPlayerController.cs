using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewPlayerController : MonoBehaviour {
	public float sprintSpeed = 1f;
	public float forwardSpeed = 6f;
	public float strafeSpeed = 5f;
	public float backSpeed = 0.085f;
	public int jumpForce = 150;
	private Rigidbody Player;
	public float distToGround;
	private Collider collider;
	private PlayerCharacter playerCharacter;
    private float sprintFOV;
    private float normalFOV;

	public Keybinds keybinds;
	
	void Awake () { 
		Player = GetComponent<Rigidbody> ();
		collider = GetComponent<Collider> ();
		distToGround = collider.bounds.extents.y;
		playerCharacter = GameObject.Find ("Player").GetComponent<PlayerCharacter> ();
		keybinds = GameObject.Find ("KeybindsManager").GetComponent<Keybinds>();
        normalFOV = Settings.fov;
        sprintFOV = Settings.fov + 5;


	}


//THIS IS BECAUSE OF A UNITY BUG
	void Update () {
		if (PauseScreen.isPaused) {
			sprintSpeed = 0;
			forwardSpeed = 0;
			strafeSpeed = 0;
			backSpeed = 0;
			jumpForce = 0;
		} else {
			sprintSpeed = 0.4f;
			forwardSpeed = 6.5f;
			strafeSpeed = 5.5f;
			backSpeed = 0.055f;
			jumpForce = 200;
		}
	}
//THIS IS BECAUSE OF A UNITY BUG


	void FixedUpdate ()  {
		//ramp down speed in air
		if (Input.GetKey (keybinds.Keybindings["Right"])) {
			Player.MovePosition (Player.position + transform.right * Time.deltaTime * strafeSpeed);
			//Debug.Log("test");
		}
		if (Input.GetKey (keybinds.Keybindings["Left"])) {
			Player.MovePosition (Player.position + -transform.right * Time.deltaTime * strafeSpeed);
		}
		if (Input.GetKey (keybinds.Keybindings["Forward"])) {
			Player.MovePosition (Player.position + transform.forward * Time.deltaTime * forwardSpeed);
			if (Input.GetKey (keybinds.Keybindings["Sprint"]) && playerCharacter.playerCurrentStamina > 0) {
				Player.MovePosition (Player.position + transform.forward * Time.deltaTime * (forwardSpeed*sprintSpeed) );
				Settings.fov = sprintFOV;
				playerCharacter.playerCurrentStamina -= .32f;
			}
			else {
				forwardSpeed = 6.5f;
                Settings.fov = normalFOV;
			}
		}
		if (Input.GetKey (keybinds.Keybindings["Back"])) {
			Player.MovePosition (Player.position + -transform.forward * Time.deltaTime * strafeSpeed);
		}
		if (Input.GetKey (keybinds.Keybindings["Jump"])) {
			if (IsGrounded ()==true) {
				Player.AddForce(Vector3.up*jumpForce);
			}
		}
		if (IsGrounded () == false) {
			Player.AddForce(Vector3.down * 9.8f);
		}
	}

	bool IsGrounded() {
		return Physics.Raycast (transform.position, - Vector3.up, distToGround + 0.1f);
	}
}
