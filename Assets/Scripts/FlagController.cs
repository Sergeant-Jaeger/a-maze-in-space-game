using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
			Destroy(transform.gameObject);
            if (UnityEditor.EditorApplication.isPlaying == true) {
                Debug.Log("Player Wins!!!");
            }
        }
    }
}
