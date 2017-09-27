using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

	public GameObject shipObj;
	public Image fade;

	ShipController ship;

	// Use this for initialization
	void Start () {
		fade.gameObject.SetActive (true);
		fade.canvasRenderer.SetAlpha (0f);
		ship = shipObj.GetComponent<ShipController> ();
		ship.AddBoost (100f);
	}

	IEnumerator StartGame() {
		yield return new WaitForSeconds (7);
		SceneManager.LoadScene ("lvl_00");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			fade.CrossFadeAlpha (1f, 7f, false);
			StartCoroutine ("StartGame");
		}
		
	}
}
