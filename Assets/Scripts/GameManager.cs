using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    [SerializeField]
    float endDelay = 3f;

    [SerializeField]
    GameObject playerPrefab;

    private GameObject[] spawnLocations;
    private bool gameOver;
    private WaitForSeconds endWait;

    void Start () {
        spawnLocations = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        gameOver = false;
        endWait = new WaitForSeconds(endDelay);

        SpawnPlayer();

        StartCoroutine(GameLoop());
	}

    private void SpawnPlayer() {
        if(spawnLocations.Length > 0) {
            Transform spawnPoint = GetRandomSpawnPoint();

            //TODO: Jack needs to fix his hacky ass shit in bb8
            GameObject player = Instantiate(playerPrefab);
            player.transform.GetChild(0).position = spawnPoint.position;
            player.transform.GetChild(0).rotation = spawnPoint.rotation;
            //END Jacks hacky shit
        } else {
            Debug.LogError("No Spawn Points set");
        }
        
    }

    private Transform GetRandomSpawnPoint() {
        int randomLocation = Random.Range(0, spawnLocations.Length);
        return spawnLocations[randomLocation].transform;
    }

    private IEnumerator GameLoop() {
        //yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());

        if(gameOver) {
            //TODO: Add game over screen
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        StartCoroutine(GameLoop());
    }

    private IEnumerator GamePlaying() {
        while(FlagsRemaining()) {
            yield return null;
        }
    }

    private IEnumerator GameEnding() {
        if(!FlagsRemaining()) {
            gameOver = true;
        }
        yield return endWait;
    }

    private bool FlagsRemaining() {
        FlagManager flagManager = gameObject.GetComponent(typeof(FlagManager)) as FlagManager;
        return flagManager.flagsRemaining() > 0;
    }
}
