using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageSlideshow : MonoBehaviour {

	public Image front;
	public Image back;
	public float interval = 5;
	public float fadeDuration = 2;

	public Sprite[] sprites;
	private int index;

	private void OnEnable () {
		StartCoroutine (SlideShow ());
	}


	private IEnumerator SlideShow () {
		if (index == sprites.Length - 1)
			index = 0;
		front.sprite = sprites [index];
		back.sprite = sprites [index + 1];
		while (true) {
			yield return new WaitForSeconds (interval);
			index = (index + 1) % sprites.Length;
			back.sprite = sprites [index];
			front.CrossFadeAlpha (0, fadeDuration, false);
			yield return new WaitForSeconds (interval);
			index = (index + 1) % sprites.Length;
			front.sprite = sprites [index];
			front.CrossFadeAlpha (1, fadeDuration, false);

		}

	}

	private IEnumerator FadeOut () {
		for (float t = 0; t < 1; t += Time.deltaTime / fadeDuration) {
			yield return null;
			//front.color = new Color (front.cro
		}
	}

}
