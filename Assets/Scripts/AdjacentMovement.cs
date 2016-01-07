using UnityEngine;
using System.Collections;

public class AdjacentMovement : MonoBehaviour {

	public Collider[] canMove;

	public bool colliderMatch(Collider col){
		for (int i = 0; i < canMove.Length; i++) {
			if (col == canMove[i]){
				return true;
			}
		}
		return false;
	}
}
