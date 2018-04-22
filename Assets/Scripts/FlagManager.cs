using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagManager : MonoBehaviour {
	[SerializeField]
	private int flagQuantity;
	[SerializeField]
	private GameObject[] spawnLocations;
	[SerializeField]
	private GameObject flagPrefab;

	private GameObject[] flags;
	private int[] spawnOccupied;

	private void Start () {
		if (flagQuantity > spawnLocations.Length)
		{
			print("Flag Quantity exceeds number of spawn points");
			flagQuantity = spawnLocations.Length;
		}
		for (int i = 0; i < flagQuantity; i++)
		{
			SpawnFlag();
		}
	}
	
	private void SpawnFlag()
	{
		while (true)
		{
			int spawn = Random.Range(0, spawnLocations.Length);
			if (spawnLocations[spawn].transform.childCount > 1) { }
			else
			{
				Instantiate(flagPrefab, spawnLocations[spawn].transform);
				break;
			}

		}
	}
}
