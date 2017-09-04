using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Paddle paddle;

    private Vector3 paddleToBallVector;
    private bool hasStarted = false;

    



	// Use this for initialization
	void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();
        // get the offset between ball and paddle
        paddleToBallVector = this.transform.position - paddle.transform.position;



    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            // put the intial position of the ball over the paddle
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(5f, 10f);
            }


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,0.5f), Random.Range(0.2f,0.10f));
        
        if (hasStarted)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
