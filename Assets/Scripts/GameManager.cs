using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float endDelay = 3f;

    [SerializeField]
    GameObject playerPrefab;

    [SerializeField]
    List<Transform> spawnLocations;

    private bool gameOver;
    private WaitForSeconds endWait;

    void Start () {
        gameOver = false;
        endWait = new WaitForSeconds(endDelay);

        SpawnPlayer();
        SetCameraTarget();

        StartCoroutine(GameLoop());
	}

    private void SpawnPlayer() {
        if(spawnLocations.Count > 0) {
            Transform spawnPoint = GetRandomSpawnPoint();
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        } else {
            Debug.LogError("No Spawn Points set");
        }
        
    }

    private void SetCameraTarget() {
        //TODO: Dynamically set camera to player
    }

    private Transform GetRandomSpawnPoint() {
        int randomLocation = UnityEngine.Random.Range(0, spawnLocations.Count);
        return spawnLocations[randomLocation].transform;
    }

    private IEnumerator GameLoop() {
        //yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());

        if(gameOver) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        StartCoroutine(GameLoop());
    }

    private IEnumerator GamePlaying() {
        while(!ZeroFlagsRemaining() || !ZeroLivesRemaining()) {
            yield return null;
        }
    }

    private IEnumerator GameEnding() {
        yield return endWait;
    }

    private bool ZeroLivesRemaining() {
        //TODO: figure out how many lives remain
        return false;
    }

    private bool ZeroFlagsRemaining() {
        //TODO: figure out if there are flags left
        return false;
    }
}
