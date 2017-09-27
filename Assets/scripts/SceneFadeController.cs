using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFadeController : MonoBehaviour {

	public Image fade;

	// Use this for initialization
	void Start () {
		fade.gameObject.SetActive (true);
		fade.canvasRenderer.SetAlpha (0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (ShipController.boostReady && Input.GetKeyDown(KeyCode.Space)) {
			fade.CrossFadeAlpha (1f, 7f, false);
			StartCoroutine ("LoadLevel", (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
		}
	}

	IEnumerator LoadLevel(int level_index) {
		yield return new WaitForSeconds (7);
		SceneManager.LoadScene (level_index);
	}

}
