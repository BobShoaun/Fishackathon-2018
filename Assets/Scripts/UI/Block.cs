using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

	public event System.Action<Block> OnBlockClick;
	public Vector2 offset;
	public float offsetTime;

	public void OnClick(){

		if (OnBlockClick != null) {
			OnBlockClick (this);
		}
	}

}
