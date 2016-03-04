using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textColorCycle : MonoBehaviour {
	private Text textLocal;
	private Color colorNow = Color.red;

	// Use this for initialization
	void Start () {
		textLocal = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		colorNow = Color.HSVToRGB( Mathf.Repeat(Time.time*0.5f, 1.0f) , 1.0f, 1.0f);
		textLocal.color = colorNow;
	}
}
