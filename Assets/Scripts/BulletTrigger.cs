using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour {

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            GameManager gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
            gameManager.KillPlayer();
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }
}