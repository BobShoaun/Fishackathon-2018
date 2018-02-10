using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour {

	List<Block> blocksToAnimate = new List<Block>();
	public TMP_Dropdown countryDropdown;
	public CountryDatabase countryDatabase;

	List<string> countryNames = new List<string>();

	void Start(){

		foreach (var country in countryDatabase.countries) {
			countryNames.Add (country.name);
		}

		PopulateList ();
		blocksToAnimate.AddRange(FindObjectsOfType<Block>());

		foreach (Block b in blocksToAnimate) {
			b.OnBlockClick += MoveBlock;
		}
	}

	void MoveBlock(Block block){
		Vector2 finalOffset = new Vector2( block.offset.x * (block.objectToMove.GetComponent<RectTransform> ().rect.width * GetComponent<Canvas> ().scaleFactor),
            block.offset.y *(block.objectToMove.GetComponent<RectTransform> ().rect.height * GetComponent<Canvas> ().scaleFactor) );
		StartCoroutine (MoveAnimation(block.objectToMove.GetComponent<RectTransform>(), finalOffset, block.offsetTime));
	}

	IEnumerator MoveAnimation(RectTransform transform, Vector2 offset, float offsetTime){
		float percent = 0;
		Vector2 startingPos = transform.position;

		while(percent < 1.0f){
			percent += Time.deltaTime / offsetTime;
			transform.position = Vector2.Lerp (startingPos, startingPos + offset, percent);
			yield return null;
		}
	}

	public void DisplayPage(GameObject objectToShow){
		objectToShow.SetActive (true);
	}

	public void PopulateList(){
		countryDropdown.AddOptions (countryNames);
	}

}
