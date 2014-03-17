using UnityEngine;
using System.Collections;

public abstract class InteractableObject : MonoBehaviour {
	private int TimesHit = 0;

	public int MaxTimesHit = 3;
	public int AmountToCreate = 3;

	public virtual void Hit (GameObject hitByObject) {
		TimesHit++;

		if (TimesHit == MaxTimesHit) {
			Collider ObjectCollider = gameObject.collider;
			Destroy(transform.gameObject);

			AstarPath.active.UpdateGraphs(ObjectCollider.bounds);

			GameObject Log = Resources.Load<GameObject>("evergreenlog_01");
			GameObject LogCreated;
			for (int i = 0; i < AmountToCreate; i++) {
				LogCreated = (GameObject) Instantiate(Log, transform.position + new Vector3(0, i, 0), Quaternion.identity);
				LogCreated.rigidbody.AddForce(new Vector3(1, 0, 1), ForceMode.Impulse);
			}
		}
	}
}
