using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public GameObject smoke;
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;

    private int timesHit;
    private LevelManager levelManager;
    private bool isBreakable;
    // Start is called before the first frame update
    void Start()
    {
        isBreakable = (this.tag == "Breakable");
        if(isBreakable)
        {
            breakableCount++;
        }

        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if(isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        int maxHits = hitSprites.Length + 1;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            levelManager.BrickDestroyed();
            GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
            smokePuff.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    // TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if(hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        
    }

}
