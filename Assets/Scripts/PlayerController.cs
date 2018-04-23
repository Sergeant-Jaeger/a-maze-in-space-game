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
			playerRB.AddForce(new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z) * speed);
		}
		if (Input.GetKey("a"))
		{
			playerRB.AddForce(-new Vector3(cameraTransform.right.x, 0f, cameraTransform.right.z) * speed);
		}
		if (Input.GetKey("d"))
		{
			playerRB.AddForce(new Vector3(cameraTransform.right.x, 0f, cameraTransform.right.z) * speed);
		}
		if (Input.GetKey("s"))
		{
			playerRB.AddForce(new Vector3(-cameraTransform.forward.x, 0f, -cameraTransform.forward.z) * speed);
		}
	}

}
