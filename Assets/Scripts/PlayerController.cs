using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	float speed;

	[SerializeField]
	Transform cameraTransform;

	private Rigidbody playerRB;

    void Start() {
        playerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() {
		if (Input.GetKey("w"))
		{
			playerRB.AddForce(cameraTransform.forward * speed);
		}
		if (Input.GetKey("a"))
		{
			playerRB.AddForce(-cameraTransform.right * speed);
		}
		if (Input.GetKey("d"))
		{
			playerRB.AddForce(cameraTransform.right * speed);
		}
		if (Input.GetKey("s"))
		{
			playerRB.AddForce(-cameraTransform.forward * speed);
		}
	}

}
