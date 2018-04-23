using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            PlayerLife playerLife = other.GetComponent("PlayerLife") as PlayerLife;
            playerLife.KillPlayer();
        }
    }
}
