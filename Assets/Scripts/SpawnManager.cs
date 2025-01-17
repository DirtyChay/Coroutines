﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject sentry;
    public Transform[] spawnPositions;
    public int spawnTime = 5;
    public bool keepSpawning;

	// Use this for initialization
	void Start () {
        // Task 2: Start Your Coroutine Here
        keepSpawning = true;
        StartCoroutine(SpawnGuys());
	}
	
	// Update is called once per frame
	void Update () {
		// Don't use Update for this task!
	}

    // Task 2: Write Your Coroutine Here
    IEnumerator SpawnGuys() {
	    while (keepSpawning) {
		    for (int i = 0; i < spawnPositions.Length; i++) {
			    GameObject newSentry = Instantiate(sentry);
			    newSentry.transform.position = spawnPositions[i].position;
			    yield return new WaitForSeconds(spawnTime);
		    }
	    }
    }
}
