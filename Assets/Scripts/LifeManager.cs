using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{

    [SerializeField]
    private Text lifeText;

    [SerializeField]
    private GameManager gameManager;

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
        lifeText.text = "Lives Remaining: " + gameManager.PlayerLives;
    }
}
