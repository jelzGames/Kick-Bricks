using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    public bool autoPlay = false;
    private Ball ball;


	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWIthMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void MoveWIthMouse()
    {
        Vector2 paddlePos = new Vector2(0.5f, this.transform.position.y);

        // Mouse position in pixels
        // Relative position = unit between 0 and 1 = mousePosition.x / screen.width 
        // Game unit or blocks = mousePosition.x / screen.width * 16
        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        paddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.7f, 15.3f);

        this.transform.position = paddlePos;

    }

    void AutoPlay()
    {
        Vector2 paddlePos = new Vector2(0.5f, this.transform.position.y);
        Vector3 ballPos = ball.transform.position;

        paddlePos.x = Mathf.Clamp(ballPos.x, 0.7f, 15.3f);

        this.transform.position = paddlePos;

    }
}
