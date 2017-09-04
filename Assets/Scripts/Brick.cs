using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    private LevelManager levelManger;

    private int timesHits;
    public Sprite[] hitSprites;

    public static int brickCount = 0;
    private bool isBreakeable;

    public AudioClip crack;

    public GameObject smoke;

    // Use this for initialization
    void Start () {
        isBreakeable = (this.tag == "breakable");
        if (isBreakeable)
        {
            brickCount++;

        }

        timesHits = 0;
        levelManger = GameObject.FindObjectOfType<LevelManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakeable)
        {
            AudioSource.PlayClipAtPoint(crack, transform.position);
            HandleHits();
        }

        //SimulateWin();
    }

    void HandleHits()
    {
        timesHits++;
        int maxHits = hitSprites.Length + 1;

        if (timesHits >= maxHits)
        {
            brickCount--;
            levelManger.BrickDestroyed();
            Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }

    }

    void SimulateWin()
    {
        levelManger.LoadNextLevel();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHits - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }

    }
}
