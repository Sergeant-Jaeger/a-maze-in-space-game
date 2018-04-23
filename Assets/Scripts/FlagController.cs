using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
            FlagManager flagManager = gameManager.GetComponent("FlagManager") as FlagManager;
            flagManager.captureFlag(gameObject);
        }
    }
}
