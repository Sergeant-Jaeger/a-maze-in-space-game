﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gameManager.KillPlayer();
        }
    }
}
