using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	public float offset_vertical;
	public float offset_horizontal;

	private Vector3 offset_vec;


	// Use this for initialization
	void Start () {
		print (player.up);
		print (player.forward);
		offset_vec = player.up * offset_vertical + player.forward * -offset_horizontal;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.position + offset_vec;
	}
}
