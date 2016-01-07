using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageManager : MonoBehaviour {

	public GameObject messageBox;
	public Text messageText;
	public static MessageManager instance;

	Image messageBoxImage;
	// Use this for initialization
	void Start () {
		messageBox.SetActive (false);
		messageBoxImage = messageBox.GetComponent<Image>();
		instance = this;

	}

	public void PostMessage (string toSay) {
		Color tempColor;
		tempColor = messageBoxImage.color;
		tempColor.a = 1.0f;
		messageBoxImage.color = tempColor;

		tempColor = messageText.color;
		tempColor.a = 1.0f;
		messageText.color = tempColor;

		messageBox.SetActive (true);
		messageText.text = toSay;
		StartCoroutine (CloseBox());
	}

	IEnumerator CloseBox(){
		yield return new WaitForSeconds (2.0f);
		for (float alpha = 1.0f; alpha >= 0.0f ; alpha -= 0.1f) {
			Color boxCol = messageBoxImage.color;
			boxCol.a = alpha;
			messageBoxImage.color = boxCol;
			Color textCol = messageText.color;
			textCol.a = alpha;
			messageText.color = textCol;
			yield return new WaitForSeconds(0.1f);
		} 
		messageBox.SetActive (false);
	}
}
