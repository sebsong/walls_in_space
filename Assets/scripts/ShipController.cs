using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
	public float spinSpeed;
	Rigidbody rb;
	float boost;
	bool boostReady;
	bool isBoosting;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		boost = 0f;
		boostReady = false;
		isBoosting = false;
	}
	
	// Update is called once per frame
	void Update () {
		Spin ();

		if (Input.GetKeyDown (KeyCode.R)) {
			Respawn ();
		}

		if (boostReady && Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine ("Boost");
		}
	}

	void Spin () {
		float rotDir;

		rotDir = Input.GetAxisRaw ("Horizontal");

		transform.Rotate (rotDir * spinSpeed * Time.deltaTime, 0, 0);
	}

	void AddBoost (float boostVal) {
		if (boost < 100f) {
			float newBoost = boost + boostVal;
			if (newBoost >= 100f) {
				boost = 100f;
				boostReady = true;
			} else {
				boost = newBoost;
			}
		}
	}

	IEnumerator Boost () {
		isBoosting = true;
		rb.isKinematic = true;
		float speed = 0f;
		while (isBoosting) {
			transform.position += Vector3.forward * speed * Time.deltaTime;
			speed += 5f;
			yield return null;
		}
	}

	void OnCollisionEnter (Collision coll) {
		rb.useGravity = true;
	}

	void OnTriggerEnter (Collider coll) {
		AddBoost (1f);
	}

	void Respawn () {
		boostReady = false;
		isBoosting = false;

		rb.isKinematic = false;
		rb.useGravity = false;

		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		transform.position = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 90, 0);
	}
}