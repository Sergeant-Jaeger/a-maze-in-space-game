using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrigger : MonoBehaviour {

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            PlayerController controller = collision.gameObject.GetComponent("PlayerController") as PlayerController;
            controller.KillPlayer();
            Destroy(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

}
