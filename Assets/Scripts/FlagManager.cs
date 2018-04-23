using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour {

	[SerializeField]
	private GameObject flagPrefab;

    private GameObject[] spawnLocations;
    private List<GameObject> flags;

	private void Start () {
        spawnLocations = GameObject.FindGameObjectsWithTag("FlagSpawn");
        flags = new List<GameObject>();
        foreach(GameObject spawnLocation in spawnLocations) {
            flags.Add(SpawnFlag(spawnLocation));
        }
	}
	
	private GameObject SpawnFlag(GameObject spawnLocation)
	{
	    return Instantiate(flagPrefab, spawnLocation.transform);
	}

    public int flagsRemaining() {
        return flags.Count;
    }

    public void captureFlag(GameObject flag) {
        flags.Remove(flag);
        Destroy(flag);
    }
}
