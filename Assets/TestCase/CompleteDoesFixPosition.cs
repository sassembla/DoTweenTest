using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CompleteDoesFixPosition : MonoBehaviour {
	int frame = 0;
	// Use this for initialization
	IEnumerator Start () {
		var s = DOTween.Sequence();
		
		var endPos = new Vector3(0,100,0);
		s.Append(transform.DOMove(endPos, 100.0f));

		while (true) {
			if (frame == 10) {
				s.Complete();
				Debug.Assert(transform.position == endPos, "not intended behaviour. position matched.");
				Debug.Log("after completed pos:" + transform.position);
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
