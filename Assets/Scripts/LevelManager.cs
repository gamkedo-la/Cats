using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public string nextLevelToLoad;
	public string currentLevel;
	public string lastLevelToLoad;
	public Transform catBedroomRoomSpawn;
	public Transform camBedroomRoomSpawn;
	public Transform catKitchenSpawn;
	public Transform camKitchenSpawn;
	public RoomSwitcher switcher;
	public Button nextLevelButton;
	public Button endGameButton;

    private TimeDialManager timer;
	public GameObject canvasComponent;
    private CatController cat;
	private bool end = false;
	public ScoreManager scoreManager;

    // Use this for initialization
    void Start () {

        timer = FindObjectOfType<TimeDialManager>();
	
		if(canvasComponent) {
			canvasComponent.SetActive(false);
		}

        cat = FindObjectOfType<CatController>();
		if(endGameButton) {
			endGameButton.gameObject.SetActive(false);
		}
    }
	
	// Update is called once per frame
	void Update () {

		if (timer && timer.CheckIfTimeIsUp() && end == false)
        {
            EndLevel();
			end = true;
        }
	}

	public void SetNextLevel(Transform camera, Transform cat, string roomName){
		if (roomName == "bedroom") {
			catBedroomRoomSpawn = cat;
			camBedroomRoomSpawn = camera;
		} else {
			catKitchenSpawn = cat;
			camKitchenSpawn = camera;
		}
	}

	public void LoadMainMenu(){
		Application.LoadLevel("mainmenu");
	}

	public void LoadIntroLevel(){
		Application.LoadLevel("intro");
	}

	public void LoadGame(){
		Application.LoadLevel ("livingroom");
	}

    public void LoadNextLevel()
    {
		if (currentLevel == nextLevelToLoad) {
			switcher.ChangeRoom (lastLevelToLoad);
			currentLevel = lastLevelToLoad;
			timer.ResetTimer (5);
		} else {
			switcher.ChangeRoom (nextLevelToLoad);
			currentLevel = nextLevelToLoad;
			timer.ResetTimer (2);
		
		}
		if(canvasComponent) {
			canvasComponent.SetActive(false);
		}
		end = false;

    }

    public void QuitGame() {
        Application.Quit();
    }

    private void EndLevel()
    {
		Camera.main.GetComponent<AudioSource> ().Stop ();
		cat.betweenLevels = true;
		if (currentLevel == lastLevelToLoad) {
			scoreManager.CheckFinalScore();
			nextLevelButton.gameObject.SetActive(false);
			if(endGameButton) {
				endGameButton.gameObject.SetActive(true);
			}
		}
		if(canvasComponent) {
			canvasComponent.SetActive(true);
		}
    }
}
