using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	List<Block> blocksToAnimate = new List<Block>();
	public Dropdown countryDropDown;
	public CountryDatabase countryDatabase;

	List<string> countryNames = new List<string>(){"Malaysia", "Indonesia", "Singapore"};

	void Start(){

		foreach (var country in countryDatabase.countries) {
			countryNames.Add (country.name);
		}

		PopulateList (countryDropDown);
		blocksToAnimate.AddRange(FindObjectsOfType<Block>());

		foreach (Block b in blocksToAnimate) {
			b.OnBlockClick += MoveBlock;
		}
	}

	void MoveBlock(Block block){
		StartCoroutine (MoveAnimation(block.objectToMove.GetComponent<RectTransform>(), block.offset, block.offsetTime));
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

	public void PopulateList(Dropdown dropDown){
		dropDown.AddOptions (countryNames);
	}

}
