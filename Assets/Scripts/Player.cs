using UnityEngine;
using System.Collections;


public class Player : MonoBehaviour {
	private CharacterController controller;
	private Transform firstPersonCamera;
	
	private Vector3 moveDirection;
	
	private float movementSpeed = 3.0F;
	private const float regularSpeed = 3.0F;
	private const float sprintSpeed = 4.0F;
	private const float jumpSpeed = 4.0F;
	private const float crouchSpeed = 1.0F;
	private bool crouchToggle = false;
	private const float gravity = 9.81F;
	private const float mouseSensitivity = 1.0F;
	private float verticalRotation = 0.0F;

	private GameObject objectHeld;
	
	void Start() {
		controller = GetComponent<CharacterController>();
		firstPersonCamera = transform.Find("FirstPersonCamera");
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
		}

		// Ability to pickup GameObject's
		if (Input.GetKeyDown(KeyCode.E)) {
			RaycastHit hit;
			if (Physics.Raycast(firstPersonCamera.position, firstPersonCamera.forward, out hit, 2)) {
				if (hit.transform.gameObject.GetComponent<Rigidbody>()) {
					objectHeld = hit.collider.gameObject;
					objectHeld.GetComponent<Rigidbody>().isKinematic = true;
				}
			}
		} else if (Input.GetKeyUp(KeyCode.E) && objectHeld) {
			if (objectHeld.GetComponent<Rigidbody>()) {
				objectHeld.GetComponent<Rigidbody>().isKinematic = false;
			}
			objectHeld = null;
		} else if (objectHeld != null) {
			objectHeld.transform.position = Vector3.MoveTowards(objectHeld.transform.position, transform.position + transform.forward, 7.0F * Time.deltaTime);
		}
		
		// Rotation
		transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSensitivity, 0);
		verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
		verticalRotation = Mathf.Clamp(verticalRotation, -60.0F, 60.0F);
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
