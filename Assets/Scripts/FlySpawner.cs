using UnityEngine;
using System.Collections;

public class FlySpawner : MonoBehaviour {
	public GameObject flyPrefab;
	public int howMany = 5;
	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnMomentLater());
	}

	IEnumerator SpawnMomentLater() {
		yield return new WaitForSeconds(0.1f);
		BoxCollider bcArea = GetComponent<BoxCollider>();

		for(int i = 0; i < howMany; i++) {
			Vector3 rndPosWithin;
			rndPosWithin = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
			rndPosWithin = transform.TransformPoint(rndPosWithin * .5f);
			GameObject.Instantiate(flyPrefab, rndPosWithin, Quaternion.identity);
		}
	}

}
