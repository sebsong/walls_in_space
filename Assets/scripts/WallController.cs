using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WallController : MonoBehaviour {

	Transform spawner;

	void Start() {
		spawner = GameObject.FindGameObjectWithTag ("wall_spawner").transform;

	}

	// Update is called once per frame
	protected virtual void Update () {
		Move ();
	}

	protected virtual void Move (){
		transform.position += Vector3.back * WallSpawner.speed * Time.deltaTime;
	}

	void OnTriggerEnter(Collider coll) {
//		StartCoroutine ("Glow");
	}

//	IEnumerator Glow() {
//	}
}
