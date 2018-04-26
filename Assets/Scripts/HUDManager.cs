using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{

    [SerializeField]
    private Text lifeText;

    private void Start()
    {
        UpdateLives();
    }

    private void Update()
    {
        UpdateLives();
    }

    private void UpdateLives()
    {
        lifeText.text = "Lives Remaining: " + GetComponent<GameManager>().PlayerLives;
    }
}
