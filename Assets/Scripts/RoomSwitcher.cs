using UnityEngine;
using System.Collections;

public class RoomSwitcher : MonoBehaviour {

	public LoadOtherRoom[] roomList;
	public int roomIndexCurrent;
	public int roomIndexNext;
	public float camTrollySpeed = 3.0f;
	public CatCam catCam;
	public CatController theCat;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.E)) {
			roomIndexNext = 0;
		}
		if (Input.GetKey (KeyCode.R)) {
			roomIndexNext = 1;
		}
		if (Input.GetKey (KeyCode.T)) {
			roomIndexNext = 2;
		}
		if (roomIndexNext != roomIndexCurrent) {
			if (catCam.enabled) {
				catCam.enabled = false;
			}
			Vector3 vectDif = roomList [roomIndexNext].cameraSpawnPoint.position - Camera.main.transform.position;
			float moveThisFrame = Time.deltaTime * camTrollySpeed;
			if (vectDif.magnitude < moveThisFrame) {
				catCam.cameraDefaultPos = roomList [roomIndexNext].cameraSpawnPoint;
				catCam.reset ();
				Camera.main.transform.position = roomList [roomIndexNext].cameraSpawnPoint.position;
				roomIndexCurrent = roomIndexNext;
				catCam.enabled = true;
				theCat.transform.position = roomList[roomIndexNext].catSpawnPoint.position;
			} else {
				Camera.main.transform.position += moveThisFrame * vectDif.normalized;
			}
		}
	}

	void FixedUpdate(){
		if (roomIndexNext != roomIndexCurrent) {
			Camera.main.transform.rotation = Quaternion.Slerp (Camera.main.transform.rotation, roomList [roomIndexNext].cameraSpawnPoint.rotation, Time.deltaTime * 1.5f);
		}
	}
}
