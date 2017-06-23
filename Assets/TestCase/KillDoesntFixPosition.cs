using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class KillDoesntFixPosition : MonoBehaviour {

	int frame = 0;
	// Use this for initialization
	IEnumerator Start () {
		var s = DOTween.Sequence();
		
		var endPos = 100f;
		s.Append(transform.DOMoveY(endPos, 100.0f));

		while (true) {
			if (frame == 10) {
				s.Kill();
				Debug.Assert(transform.position.y != endPos, "not intended behaviour. position matched.");
				Debug.Log("after killed pos:" + transform.position.y);
				yield break;
			}
			yield return null;
			frame++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
