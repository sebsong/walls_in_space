using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move (){
		transform.position += Vector3.back * WallSpawner.speed * Time.deltaTime;
	}
}
