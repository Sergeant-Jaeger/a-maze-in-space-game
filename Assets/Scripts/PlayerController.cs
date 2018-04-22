using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	float speed;

    [SerializeField]
    List<Transform> spawnLocations;
	
    private Rigidbody playerRB;

    void Start() {
        playerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

        playerRB.AddForce(movement * speed);
            
    }

    private void spawn() {
        if (spawnLocations.Count > 0) {
            int randomLocation = Random.Range(0, spawnLocations.Count);
            transform.position = spawnLocations[randomLocation].transform.position;
        } else {
            Debug.LogError("No Respawn Zones have been placed");
        }
        
    }

    public void KillPlayer() {
        spawn();
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
    }
}
