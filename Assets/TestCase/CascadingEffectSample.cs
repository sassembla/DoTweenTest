using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/**
	高速でエフェクトを生成するも、
	最大でも5個までのリミットを設ける。

	5個あるときに新しいものが来たら、一番古いものをCompleteさせて消す。
 */
public class CascadingEffectSample : MonoBehaviour {
	private int maxCount = 5;

	public GameObject cascadingEffectObj;

	// Use this for initialization
	void Start () {
		// do nothing.
	}

	private List<Sequence> runningAnimations = new List<Sequence>();

	private void Animation () {
		// create effect instance(can be cached. get from object pool).
		var newEffectObj = Instantiate(cascadingEffectObj);
		newEffectObj.name = "generated frame:" + frame;

		var seq = DOTween.Sequence();
		seq.Append(newEffectObj.transform.DOMoveY(100f, 1));
		seq.OnComplete(() => {
			// delete from list.
			if (runningAnimations.Contains(seq)) {
				runningAnimations.Remove(seq);
			}

			// delete object itself(can be cached. back to object pool).
			Destroy(newEffectObj);
		});

		// add this sequence to running animation list.
		runningAnimations.Add(seq);
	}
	
	private int frame = 0;

	// Update is called once per frame
	void Update () {

		// very high frequency.
		if (frame % 2 == 0) {

			/*
				wanna show new effect!
			 */

			// keep max count.
			if (maxCount < runningAnimations.Count) {
				var deleteCount = runningAnimations.Count - maxCount;
				
				for (var i = 0; i < deleteCount; i++) {
					// complete contains self deletion from runningAnimations list.
					runningAnimations[0].Complete();
				}
			}

			// add new animation.
			Animation();
			
		}
		frame++;
	}
}
