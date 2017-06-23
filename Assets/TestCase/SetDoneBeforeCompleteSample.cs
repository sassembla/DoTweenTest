using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SetDoneBeforeCompleteSample : MonoBehaviour {

	private Sequence runningAnimation;

	// Use this for initialization
	void Start () {
		Animation();
	}

	float endPos = 100f;

	private void Animation () {
		var s = DOTween.Sequence();
		
		// take 100f.
		s.Append(transform.DOMoveY(endPos, 100f));

		// set global param.
		runningAnimation = s;
	}
	
	int frame;
	// Update is called once per frame
	void Update () {
		if (frame % 10 == 0) {
			// cancel animation immeditately.
			if (runningAnimation != null) {
				runningAnimation.Complete();
				Debug.Assert(transform.position.y == endPos, "not match.");

				runningAnimation = null;

				// reset pos & run new animation.
				transform.position = new Vector3(transform.position.x, 0, transform.position.z);
				Animation();
			}
		}
		frame++;
	}
}
