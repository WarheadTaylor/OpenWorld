using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	private CharacterController controller;
	private Transform firstPersonCamera;
	
	private Vector3 moveDirection;
	
	private float movementSpeed = 3.0F;
	private const float regularSpeed = 2.0F;
	private const float sprintSpeed = 4.0F;
	private const float jumpSpeed = 4.0F;
	private const float crouchSpeed = 1.0F;
	private const float gravity = 9.81F;
	private const float mouseSensitivity = 1.0F;
	private float verticalRotation = 0.0F;
	
	void Start() {
		controller = GetComponent<CharacterController>();
		firstPersonCamera = transform.Find("FirstPersonCamera");
		if (!Application.isEditor) {
			Screen.showCursor = false;
		}
	}
	
	void Update() {
		// Movement
		if (controller.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * movementSpeed;
			moveDirection = transform.rotation * moveDirection;
			
			if (Input.GetButton("Jump")) {
				moveDirection.y = jumpSpeed;
			}
			
			// Control sprinting
			if (Input.GetKeyDown(KeyCode.LeftShift)) {
				movementSpeed = sprintSpeed;
			} else if (Input.GetKeyUp(KeyCode.LeftShift)) {
				movementSpeed = regularSpeed;
			}
			
			// Control crouching
			if (Input.GetKeyDown(KeyCode.LeftControl)) {
				movementSpeed = crouchSpeed;
				firstPersonCamera.transform.Translate(0, -0.3F, 0);
			} else if (Input.GetKeyUp(KeyCode.LeftControl)) {
				movementSpeed = regularSpeed;
				firstPersonCamera.transform.Translate(0, 0.3F, 0);
			}

			// Quit Game
			if (Input.GetKeyUp(KeyCode.Escape)) {
				Application.Quit();
			}
		}
		
		// Rotation
		transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -60.0F, 60.0F);
		firstPersonCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}
}
