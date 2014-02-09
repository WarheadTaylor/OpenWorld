using UnityEngine;
using System.Collections;

public sealed class UseWeapon : MonoBehaviour {
	private Transform FirstPersonCamera;
	private ObjectInteraction LocalObjectInteraction;

	private int TimesHit = 0;

	void Start () {
		FirstPersonCamera = transform.Find("FirstPersonCamera");
		LocalObjectInteraction = transform.GetComponent<ObjectInteraction>();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Mouse0)) {
			if (LocalObjectInteraction.ItemInHand.tag == "Weapon") {
				LocalObjectInteraction.ItemInHand.GetComponent<Animation>().Play("hit");
			}
		}
	}

	public void Hit () {
		RaycastHit hit;
		if (Physics.Raycast(FirstPersonCamera.position, FirstPersonCamera.forward, out hit, 1)) {
			if (hit.transform.name.IndexOf("evergreen") != -1) {
				TimesHit += 1;

				if (TimesHit == 3) {
					TimesHit = 0;

					Destroy(hit.transform.gameObject);

					GameObject Log = Resources.Load<GameObject>("evergreenlog_01");
					GameObject LogCreated;
					for (int i = 0; i < 3; i++) {
						LogCreated = (GameObject) Instantiate(Log, hit.transform.position + new Vector3(0, i, 0), Quaternion.identity);
						LogCreated.rigidbody.AddForce(new Vector3(1, 0, 1), ForceMode.Impulse);
					}
				}
			}
		}
	}

}
