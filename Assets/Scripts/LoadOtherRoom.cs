using UnityEngine;
using System.Collections;

public class LoadOtherRoom : MonoBehaviour {

	public string otherRoomName;
	public Transform roomSpawnPoint;
	public Transform cameraSpawnPoint;
	public Transform catSpawnPoint;

	// Use this for initialization

	IEnumerator LoadLevel(){
		Application.LoadLevelAdditive (otherRoomName);
		yield return new WaitForSeconds (0.1f);
		GameObject tempGO = GameObject.Find (otherRoomName);
		tempGO.transform.position = roomSpawnPoint.position;
		cameraSpawnPoint = tempGO.transform.Find ("MainCamSpawnPoint");
		cameraSpawnPoint.name += otherRoomName;
		catSpawnPoint = tempGO.transform.Find ("CatSpawnPoint");

	}
	void Start () {
		if (otherRoomName.Length > 1) {
			StartCoroutine (LoadLevel());
		}
	}
}
