using UnityEngine;
using System.Collections;

public class NewPlayerController : MonoBehaviour {
	public float sprintSpeed = 1f;
	public float forwardSpeed = 8f;
	public float strafeSpeed = 7f;
	public float backSpeed = 0.085f;
	public int jumpForce = 150;
	private Rigidbody Player;
	public float distToGround;
	private Collider collider;
	private PlayerCharacter playerCharacter;
	
	void Awake () { //Generally use Awake () instead of Start () for things like this
		Player = GetComponent<Rigidbody> ();
		collider = GetComponent<Collider> ();
		distToGround = collider.bounds.extents.y;
		playerCharacter = GameObject.Find ("Player").GetComponent<PlayerCharacter> ();
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
			sprintSpeed = 1f;
			forwardSpeed = 8f;
			strafeSpeed = 7f;
			backSpeed = 0.085f;
			jumpForce = 150;
		}
	}
//THIS IS BECAUSE OF A UNITY BUG


	void FixedUpdate ()  {
		if (Input.GetKey (KeyCode.D)) {
			Player.MovePosition (Player.position + transform.right * Time.deltaTime * strafeSpeed);
		}
		if (Input.GetKey (KeyCode.A)) {
			Player.MovePosition (Player.position + -transform.right * Time.deltaTime * strafeSpeed);
		}
		if (Input.GetKey (KeyCode.W)) {
			Player.MovePosition (Player.position + transform.forward * Time.deltaTime * forwardSpeed);
			if (Input.GetKey (KeyCode.LeftShift)) {
				Player.MovePosition (Player.position + transform.forward * Time.deltaTime * (forwardSpeed+sprintSpeed) );
				//Settings.fov = Settings.fov+10;
				playerCharacter.playerCurrentStamina -= .32f;
			}
			else {
				forwardSpeed = 8.0f;

			}
		}
		if (Input.GetKey (KeyCode.S)) {
			Player.MovePosition (Player.position + -transform.forward * Time.deltaTime * strafeSpeed);
		}
		if (Input.GetKey (KeyCode.Space)) {
			if (IsGrounded ()==true) {
				Player.AddForce(Vector3.up*jumpForce);
			}
		}
	}

	bool IsGrounded() {
		return Physics.Raycast (transform.position, - Vector3.up, distToGround + 0.1f);
	}
}
