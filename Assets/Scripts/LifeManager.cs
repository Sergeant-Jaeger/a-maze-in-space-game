using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour {

    [SerializeField]
    private Text lifeText;

    [SerializeField]
    private GameManager gameManager;

	// Use this for initialization
	void Start ()
    {
        UpdateLives();
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpdateLives();
	}

    private void UpdateLives()
    {
        lifeText.text = "Lives Remaining: " + gameManager.GetLives();
    }
}
