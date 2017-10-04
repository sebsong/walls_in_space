using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour {
	public float spinSpeed;
	Rigidbody rb;
	float boost;
	public static bool boostReady;
	bool isBoosting;

	public Slider boostSlider;
	public GameObject boostReadyEffect;

	public AudioSource music;
	public AudioSource zoom;
	public AudioSource engine;
	public AudioSource take_off;
	public AudioSource hit;
	public AudioSource crash;

	public static bool inMenu;

	private bool isHit;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();

		boost = 10f;
		boostSlider.value = boost;

		boostReady = false;
		isBoosting = false;

		isHit = false;

		if (inMenu) {
			ModifyBoost (100f);
			inMenu = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Spin ();

		if (Input.GetKeyDown (KeyCode.R)) {
			Respawn ();
		}

		if (Input.GetKeyDown (KeyCode.M)) {
			SceneManager.LoadScene ("menu");
		}

		if (boostReady && Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine ("Boost");
		}

//		if (Input.GetKeyDown (KeyCode.X)) {
//			AddBoost (100f);
//		}
	}

	void Spin () {
		float rotDir;

		rotDir = Input.GetAxisRaw ("Horizontal");

		transform.Rotate (rotDir * spinSpeed * Time.deltaTime, 0, 0);
	}

	void ModifyBoost (float boostVal) {
		if (boost < 100f && boost >= 0f) {

			float newBoost = boost + boostVal;

			if (newBoost >= 100f) {
				boost = 100f;
				boostReady = true;
				boostReadyEffect.SetActive (true);
				engine.Play ();
			} else if (newBoost < 0f) {
				boost = 0f;
				crash.Play ();
				rb.constraints = RigidbodyConstraints.None;
				rb.useGravity = true;
			} else {
				boost = newBoost;
				if (boostVal < 0f) {
					hit.Play ();
				}
			}
			boostSlider.value = boost;
		}
	}

	IEnumerator Boost () {
		engine.Stop ();
		take_off.Play ();
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
		isHit = true;
		ModifyBoost (-WallSpawner.speed / 5f);
	}

	void OnTriggerEnter (Collider coll) {
		if (!isHit) {
			ModifyBoost (WallSpawner.speed / 10f);
			zoom.Play ();
		}
		isHit = false;
	}

	void Respawn () {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
//		boost = 0f;
//		boostSlider.value = boost;
//
//		engine.Stop ();
//		boostReadyEffect.SetActive (false);
//
//		boostReady = false;
//		isBoosting = false;
//
//		rb.isKinematic = false;
//		rb.useGravity = false;
//
//		rb.velocity = Vector3.zero;
//		rb.angularVelocity = Vector3.zero;
//
//		transform.position = Vector3.zero;
//		transform.rotation = Quaternion.Euler (0, 90, 0);
//
//		music.Play ();
	}
}