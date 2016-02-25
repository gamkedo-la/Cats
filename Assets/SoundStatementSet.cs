using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[Serializable]
public class SoundPhrase
{
	public AudioClip soundFile;
	public string statement;
}

public class SoundStatementSet : MonoBehaviour {
	public SoundPhrase[] soundArray;
	public Text endPhraseText;
	private bool blocked = false;

	IEnumerator clearText() {
		blocked = true;
		yield return new WaitForSeconds(2.0f);
		endPhraseText.text = "";
		blocked = false;
	}

	void Start() {
		if(endPhraseText) {
			endPhraseText.text = "";
		}
	}

	public void RandomStatement() {
		if(blocked == false && soundArray.Length > 0) {
			SoundPhrase endStatement = soundArray[UnityEngine.Random.Range(0, soundArray.Length)];
			SoundManager.instance.PlayClipOn(endStatement.soundFile,
				Camera.main.transform.position, 1, Camera.main.transform);
			if(endPhraseText) {
				endPhraseText.text = endStatement.statement;
				StartCoroutine(clearText());
			}
		}
	}
}
