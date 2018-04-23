using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

    public void KillPlayer() {
        GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent("GameManager") as GameManager;
        gameManager.KillPlayer();
    }
}
