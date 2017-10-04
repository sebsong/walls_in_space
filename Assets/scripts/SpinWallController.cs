using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinWallController : WallController {

	public float spinSpeed;

	protected override void Update () {
		base.Update ();
		Spin ();
	}

	void Spin () {
		transform.Rotate (spinSpeed * Time.deltaTime, 0, 0);
	}
}
