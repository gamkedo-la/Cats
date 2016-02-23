using UnityEngine;
using System.Collections;

public class WhackaPooGrid : MonoBehaviour {

	public GameObject litterChunkAlpha;
	public int rows = 3;
	public int cols = 4;
	// Use this for initialization
	void Start () {
		for (int r = 0; r < rows; r++) {
			for(int c = 0; c < cols; c++){
				GameObject litterChunk = GameObject.Instantiate(litterChunkAlpha, litterChunkAlpha.transform.position + litterChunkAlpha.transform.right * c * litterChunkAlpha.transform.lossyScale.x + 
				                       litterChunkAlpha.transform.forward * r * litterChunkAlpha.transform.lossyScale.z, litterChunkAlpha.transform.rotation) as GameObject;
				litterChunk.transform.parent = transform;
				litterChunk.transform.position += Vector3.up * Random.Range(-0.02f, 0.02f);
			}
		}
		Destroy (litterChunkAlpha);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
