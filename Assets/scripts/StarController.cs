using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour {

	public Transform player;
	public Transform follow;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = follow.position;
		transform.localEulerAngles = new Vector3 (player.localEulerAngles.x, player.localEulerAngles.y + 180, 0);
	}
}
