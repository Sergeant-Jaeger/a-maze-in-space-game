using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private int playerLives = 2;

    [SerializeField]
    private float endDelay = 0f;

    [SerializeField]
    private GameObject playerPrefab;

    private GameObject player;
    private GameObject[] spawnLocations;
    private string gameResult;
    private WaitForSeconds endWait;
    private FlagManager flagManager;

    public void KillPlayer()
    {
        playerLives--;
        RespawnPlayer();
    }

    public void RespawnPlayer()
    {
        Transform spawnPoint = GetRandomSpawnPoint();

        player.transform.position = spawnPoint.position;
        player.transform.rotation = spawnPoint.rotation;
        Rigidbody playerRB = player.GetComponentInChildren<Rigidbody>();
        playerRB.velocity = Vector3.zero;
        playerRB.angularVelocity = Vector3.zero;
    }

    private void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        endWait = new WaitForSeconds(endDelay);

        SpawnPlayer();

        flagManager = gameObject.GetComponent<FlagManager>();
        flagManager.SpawnFlags();

        StartCoroutine(GameLoop());
    }

    private void SpawnPlayer()
    {
        if (spawnLocations.Length > 0)
        {
            player = Instantiate(playerPrefab);
            RespawnPlayer();
        }
        else
        {
            Debug.LogError("No Spawn Points set");
        }
    }

    private Transform GetRandomSpawnPoint()
    {
        int randomLocation = Random.Range(0, spawnLocations.Length);
        return spawnLocations[randomLocation].transform;
    }

    private IEnumerator GameLoop()
    {
        ////yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());

        if (gameResult != null)
        {
            // TODO: Add game over screen
            Debug.Log(gameResult);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        // Might not need, will test
        ////StartCoroutine(GameLoop());
    }

    private IEnumerator GamePlaying()
    {
        while (FlagsRemaining() && LivesRemaining())
        {
            yield return null;
        }
    }

    private IEnumerator GameEnding()
    {
        if (!FlagsRemaining())
        {
            gameResult = "You Won!!!";
        }
        else if (!LivesRemaining())
        {
            gameResult = "You Suck!!!";
        }

        yield return endWait;
    }

    private bool LivesRemaining()
    {
        return playerLives > 0;
    }

    private bool FlagsRemaining()
    {
        return flagManager.FlagsRemaining() > 0;
    }
}
