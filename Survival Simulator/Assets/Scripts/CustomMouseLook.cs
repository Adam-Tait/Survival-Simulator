using UnityEngine;
using System.Collections;

public class CustomMouseLook : MonoBehaviour {
	public static float Xsensitivity = 2.0f;
	public float Ysensitivity = 2.0f;
	public GameObject Player;
	private float rotationY = 0f;

	void Awake () {
		Player = GameObject.Find ("Player");
	}

	void Update () {
		Ysensitivity = Xsensitivity;
		float mouseX = Input.GetAxis ("Mouse X") * Xsensitivity;
		rotationY += Input.GetAxis ("Mouse Y") * Ysensitivity;
		rotationY = Mathf.Clamp (rotationY, -62, 65);
		transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, transform.localEulerAngles.z);
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		Player.transform.Rotate (0, mouseX, 0);
		Camera.main.fieldOfView = Settings.fov;
	}
}
