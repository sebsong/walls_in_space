using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {
	public float spinSpeed;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		Spin ();

		if (Input.GetKeyDown (KeyCode.R)) {
			Respawn ();
		}
	}

	void Spin () {
		float rotDir;

		rotDir = Input.GetAxisRaw ("Horizontal");

		transform.Rotate (rotDir * spinSpeed * Time.deltaTime, 0, 0);
	}

	void OnCollisionEnter(Collision coll) {
		rb.useGravity = true;
	}

	void Respawn () {
		rb.useGravity = false;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		transform.position = Vector3.zero;
		transform.rotation = Quaternion.Euler (0, 90, 0);
	}
}