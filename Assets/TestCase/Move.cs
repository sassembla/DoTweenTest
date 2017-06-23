using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Move : MonoBehaviour {

	int frame = 0;
	// Use this for initialization
	IEnumerator Start () {
		var s = DOTween.Sequence();
		
		s.Append(transform.DOMove(new Vector3(0,100,0), 100.0f));

		while (true) {
			if (frame == 10) {
				s.Kill();
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
