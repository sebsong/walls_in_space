using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour {
	public Transform wall;
	public Transform player;

	public float spawn_time;
	public float base_spawn_time;

	public static float speed;
	public static float base_speed;

	public float speedup_scaling;

	Queue<Transform> wall_pool;
	Queue<Transform> wall_active;

	float cooldown;

	float max_dist;

	// Use this for initialization
	void Start () {
		wall_pool = new Queue<Transform> ();
		wall_active = new Queue<Transform> ();
		cooldown = 0f;
		base_speed = 10f;
		speed = base_speed;

		max_dist = Vector3.Distance (player.position, transform.position) + 20f;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.R)) {
			Reset ();
		}

		if (cooldown <= 0) {
			SpawnWall ();
			cooldown = spawn_time;
		}
		cooldown -= Time.deltaTime;

		if (wall_active.Count > 0) {
			CheckActiveWall ();
		}

		if (speed < 50f) {
			speed += speedup_scaling * Time.deltaTime;
		}
		if (spawn_time > 1f) {
			spawn_time -= 0.1f * speedup_scaling * Time.deltaTime;
		}
	}

	void SpawnWall () {
		Transform spawned_wall;
		Quaternion wall_rot;

		wall_rot = Quaternion.Euler (Random.Range (0f, 360f), 90, 0);
		if (wall_pool.Count > 0) {
			spawned_wall = wall_pool.Dequeue();
			spawned_wall.gameObject.SetActive (true);
			spawned_wall.position = transform.position;
			spawned_wall.rotation = wall_rot;
		} else {
			spawned_wall = Instantiate (wall, transform.position, wall_rot);
		}

		wall_active.Enqueue (spawned_wall);
	}

	void CheckActiveWall () {
		Transform active_wall;

		active_wall = wall_active.Peek ();
		if (Vector3.Distance (active_wall.position, transform.position) > max_dist) {
			active_wall.gameObject.SetActive (false);
			wall_pool.Enqueue (wall_active.Dequeue ());
		}
	}

	void Reset () {
		foreach (Transform w in wall_pool) {
			Destroy(w.gameObject);
		}
		foreach (Transform w in wall_active) {
			Destroy(w.gameObject);
		}
		wall_pool.Clear ();
		wall_active.Clear ();
		cooldown = 0f;
		spawn_time = base_spawn_time;
		speed = base_speed;
	}
}
