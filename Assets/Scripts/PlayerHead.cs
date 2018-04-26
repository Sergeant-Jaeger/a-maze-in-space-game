using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{

    public Transform mainBody;
    public Transform cameraTransform;

    private void Update()
    {
        transform.position = mainBody.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(cameraTransform.forward.x, cameraTransform.forward.y + 0.4f, cameraTransform.forward.z));
    }
}
