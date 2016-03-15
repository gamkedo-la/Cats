using UnityEngine;
using System.Collections;

public class CatWanderMenu : MonoBehaviour {

	public WayPointData[] wayPointList;
	public CatController kitty;
	public int seekingWayPoint = 0;


	public IEnumerator MoveKitty(Transform nextWP){
		yield return new WaitForSeconds (1);
		kitty.MoveToTarget (nextWP);
		kitty.moving = true;
	}
	// Update is called once per frame
	void Update () {
		if (kitty.moving == false) {
			int tempWayPoint = Random.Range (0, wayPointList.Length);
			while (tempWayPoint == seekingWayPoint) {
				tempWayPoint = Random.Range (0, wayPointList.Length);
			}
			seekingWayPoint = tempWayPoint;
			WayPointData nextWP = wayPointList [seekingWayPoint];
			StartCoroutine (MoveKitty (nextWP.transform));
		}
	}
}