using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public Rigidbody2D playerRigidbody;
    private SpriteRenderer playerSpriteRenderer;

    // Use this for initialization
	void Start () {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        playerRigidbody.velocity = movement * 2;

        if(Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine(FadeToBlack());
        }
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") {
            playerRigidbody.velocity = Vector2.zero;
        }
    }

    // Task 1: Write Your Coroutine Here
    IEnumerator FadeToBlack() {
        Debug.Log("yo");
        Color original = playerSpriteRenderer.color;
        float elapsedTime = 0;
        float totalTransitionTime = 3;
        while (original != Color.black) {
            playerSpriteRenderer.color = Color.Lerp(original, Color.black, elapsedTime / totalTransitionTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}