using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {

	List<Block> blocksToAnimate = new List<Block>();

	void Start(){
		blocksToAnimate.AddRange(FindObjectsOfType<Block>());
	}

	void MoveBlock(Block block){
		StartCoroutine (MoveAnimation(block.transform, block.offset, block.offsetTime));
	}

	IEnumerator MoveAnimation(Transform transform, Vector2 offset, float offsetTime){
		float percent = 0;
		Vector2 startingPos = transform.position;

		while(percent > 1.0f){
			percent += Time.deltaTime / offsetTime;
			transform.position = Vector2.Lerp (startingPos, startingPos + offset, percent);
			yield return null;
		}


	}


}
