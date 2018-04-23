using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZoneTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerRespawn(other.gameObject);
        }
    }

    void playerRespawn(GameObject player) {
        PlayerLife playerLife = player.GetComponent("PlayerLife") as PlayerLife;
        playerLife.KillPlayer();
    }
}
