using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    bool moving;

	// Use this for initialization
	void Start () {
        moving = false;
	}
	
	// Update is called once per frame
	void Update () {
		// Don't use Update for this task
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Task 3: Start Your Coroutine Here
        if (collision.gameObject.CompareTag("Player") && moving == false) {
	        // investigate
	        moving = true;
	        Vector3 location = collision.gameObject.transform.position;
	        StartCoroutine(Investigate(location));
        }
    }

    // Task 3: Write Your Coroutine Here
    IEnumerator Investigate(Vector3 coords) {
	    Vector3 start = transform.position;
	    float elapsedTime = 0;
	    float totalTransitionTime = 5;
	    while (transform.position != coords) {
		    transform.position = Vector3.Lerp(start, coords, elapsedTime / totalTransitionTime);
		    elapsedTime += Time.deltaTime;
		    yield return null;
	    }

	    moving = false;
    }
}
