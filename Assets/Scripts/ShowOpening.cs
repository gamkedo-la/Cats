using UnityEngine;
using System.Collections;


public class ShowOpening : MonoBehaviour {
	public bool skipOpening = false;

	public Canvas gameUI;
	public Canvas titleUI;
	public LevelManager levelMan;
	public ScoreManager scoring;
	public TimeDialManager timer;
	public AudioClip openingVoice;
	public CatController catController;
	private Animator myAnim;
	private CatCam catCam;

	void setOpeningStates(bool turnOffOpening) {
		if(turnOffOpening == false) {
			SoundManager.instance.PlayClipOn(openingVoice,
				Camera.main.transform.position, 1, Camera.main.transform);
		}

		levelMan.enabled = turnOffOpening;
		catController.enabled = turnOffOpening;
		catCam.enabled = turnOffOpening;
		myAnim.enabled = (turnOffOpening == false);
		scoring.enabled = turnOffOpening;
		timer.enabled = turnOffOpening;
		gameUI.enabled = turnOffOpening;
		titleUI.enabled = (turnOffOpening == false);
	}

	// Use this for initialization
	void Start () {
		myAnim = GetComponent<Animator>();
		catCam = GetComponent<CatCam>();

		setOpeningStates(skipOpening);
	}
	
	// Update is called once per frame
	public void EndOpeningSequence() {
		setOpeningStates(true);
	}
}
