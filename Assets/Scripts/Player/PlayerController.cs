using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private GameObject cameraObject;
    private GameObject cameraPlayer;

    [SerializeField]
    private GameObject headObject;
    private GameObject headPlayer;

    private Rigidbody playerRB;

    private void Start()
    {
        headPlayer = Instantiate(headObject);
        cameraPlayer = Instantiate(cameraObject);
        playerRB = GetComponent<Rigidbody>();
        headPlayer.GetComponent<PlayerHead>().MainBody = transform;
        headPlayer.GetComponent<PlayerHead>().CameraTransform = cameraPlayer.transform;
        cameraPlayer.GetComponent<MouseOrbit>().Target = transform;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey("w"))
        {
            playerRB.AddForce(new Vector3(cameraPlayer.transform.forward.x, 0f, cameraPlayer.transform.forward.z) * speed);
        }

        if (Input.GetKey("a"))
        {
            playerRB.AddForce(-new Vector3(cameraPlayer.transform.right.x, 0f, cameraPlayer.transform.right.z) * speed);
        }

        if (Input.GetKey("d"))
        {
            playerRB.AddForce(new Vector3(cameraPlayer.transform.right.x, 0f, cameraPlayer.transform.right.z) * speed);
        }

        if (Input.GetKey("s"))
        {
            playerRB.AddForce(new Vector3(-cameraPlayer.transform.forward.x, 0f, -cameraPlayer.transform.forward.z) * speed);
        }
    }

    private void OnDestroy()
    {
        Destroy(headPlayer);
        Destroy(cameraPlayer);
    }
}
