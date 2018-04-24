using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGizmo : MonoBehaviour {

	[SerializeField]
	private Color color;

	private void OnDrawGizmos() {
		Gizmos.color = color;

		// Change to DrawMesh later for customized spawn point gizmos
		Gizmos.DrawSphere(transform.position, 0.6f);
	}
}
