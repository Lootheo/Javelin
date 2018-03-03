using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SquareLoopAnimator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		transform.DOScale(1.3f,0.2f).SetLoops(-1,LoopType.Yoyo);
	}
	
}
