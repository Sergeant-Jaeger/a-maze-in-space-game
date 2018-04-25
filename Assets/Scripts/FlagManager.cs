using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour
{

    [SerializeField]
    private GameObject flagPrefab;

    private GameObject[] spawnLocations;
    private List<GameObject> flags = new List<GameObject>();

    public int FlagsRemaining()
    {
        return flags.Count;
    }

    public void CaptureFlag(GameObject flag)
    {
        flags.Remove(flag);
        Destroy(flag);
    }

    private void Start()
    {
        spawnLocations = GameObject.FindGameObjectsWithTag("FlagSpawn");
        foreach (GameObject spawnLocation in spawnLocations)
        {
            flags.Add(SpawnFlag(spawnLocation));
        }
    }

    private GameObject SpawnFlag(GameObject spawnLocation)
    {
        return Instantiate(flagPrefab, spawnLocation.transform);
    }
}
