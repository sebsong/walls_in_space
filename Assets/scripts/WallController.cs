using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WallController : MonoBehaviour {

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
