using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameController");
            FlagManager flagManager = gameManager.GetComponent<FlagManager>();
            flagManager.CaptureFlag(gameObject);
        }
    }
}
