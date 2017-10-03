using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBlink : MonoBehaviour {
	Text t;
	string original;

	// Use this for initialization
	void Start () {
		t = GetComponent<Text> ();
		original = t.text;
		StartCoroutine ("Blink");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Blink () {
		while (true) {
			yield return new WaitForSeconds (.75f);
			t.text = "";
			yield return new WaitForSeconds (.75f);
			t.text = original;
		}
	}
}
