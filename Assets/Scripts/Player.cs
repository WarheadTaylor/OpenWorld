using UnityEngine;
using System.Collections;


public sealed class Player : MonoBehaviour {
	private CharacterController controller;
	private Transform firstPersonCamera;
	
	private Vector3 moveDirection;
	
	private float movementSpeed = 3.0F;
	private const float regularSpeed = 3.0F;
	private const float sprintSpeed = 5.0F;
	private const float jumpSpeed = 3.0F;
	private const float crouchSpeed = 1.0F;
	private bool crouchToggle = false;
	private const float gravity = 9.81F;
	private const float mouseSensitivity = 1.5F;
	private float verticalRotation = 0.0F;

	void Start() {
		controller = GetComponent<CharacterController>();
		firstPersonCamera = transform.Find("FirstPersonCamera");
		moveDirection = new Vector3(0, 0, 0);
	}
	
	void Update() {
		moveDirection.x = Input.GetAxis("Horizontal") * movementSpeed;
		moveDirection.z = Input.GetAxis("Vertical") * movementSpeed;
		moveDirection = transform.rotation * moveDirection;

		if (controller.isGrounded) {
			if (Input.GetButtonDown("Jump")) {
				moveDirection.y = jumpSpeed;
			}
		}
		
		// Control sprinting
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") > 0.0F) {
			movementSpeed = sprintSpeed;
		} else if (Input.GetKeyUp(KeyCode.LeftShift) || (Input.GetKey(KeyCode.LeftShift) && Input.GetAxis("Vertical") < 0.2F)) {
			movementSpeed = regularSpeed;
		}
		
		// Control crouching
		if (Input.GetKeyDown(KeyCode.LeftControl) && crouchToggle == false) {
			movementSpeed = crouchSpeed;
			firstPersonCamera.transform.Translate(0, -0.3F, 0);
		} else if (Input.GetKeyUp(KeyCode.LeftControl) && crouchToggle == false) {
			movementSpeed = regularSpeed;
			firstPersonCamera.transform.Translate(0, 0.3F, 0);
		} else if (Input.GetKeyDown(KeyCode.C)) {
			if (crouchToggle == true) {
				movementSpeed = regularSpeed;
				firstPersonCamera.transform.Translate(0, 0.3F, 0);
			} else {
				movementSpeed = crouchSpeed;
				firstPersonCamera.transform.Translate(0, -0.3F, 0);
			}
			crouchToggle = !crouchToggle;
		}
		
		// Rotation
		transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -80.0F, 80.0F);
		firstPersonCamera.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
		
		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic) {
			return;
		}
		
		if (hit.moveDirection.y < -0.3F) {
			return;
		}
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * 2.0F;
	}
}
