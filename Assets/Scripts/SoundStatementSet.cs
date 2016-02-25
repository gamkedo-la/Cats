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
	int prevIdx = -1;

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
			int pickPhrase = -1;
			int safetyCatch = 100;

			if(soundArray.Length == 1) {
				pickPhrase = 0;
			} else do {
				pickPhrase = UnityEngine.Random.Range(0, soundArray.Length);
			} while(pickPhrase == prevIdx && safetyCatch-- > 0);

			prevIdx = pickPhrase;
			SoundPhrase endStatement = soundArray[pickPhrase];
			SoundManager.instance.PlayClipOn(endStatement.soundFile,
				Camera.main.transform.position, 1, Camera.main.transform);
			if(endPhraseText) {
				endPhraseText.text = endStatement.statement;
				StartCoroutine(clearText());
			}
		}
	}
}
