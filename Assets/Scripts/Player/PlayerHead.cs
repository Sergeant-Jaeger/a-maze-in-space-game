﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHead : MonoBehaviour
{

    private Transform mainBody;
    private Transform cameraTransform;

    public Transform MainBody
    {
        set
        {
            mainBody = value;
        }
    }

    public Transform CameraTransform
    {
        set
        {
            cameraTransform = value;
        }
    }

    private void Update()
    {
        transform.position = mainBody.position;
        transform.rotation = Quaternion.LookRotation(new Vector3(cameraTransform.forward.x, cameraTransform.forward.y + 0.4f, cameraTransform.forward.z));
    }
}
