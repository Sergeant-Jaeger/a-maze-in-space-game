using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerLife playerLife = collision.gameObject.GetComponent("PlayerLife") as PlayerLife;
            playerLife.KillPlayer();
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

}
