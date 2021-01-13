using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public Sprite emptyHouse;
    public Sprite yourHouse;
    private UnityEngine.SpriteRenderer checkpointSpriteRenderer; //is added to be able to change SpriteRenderer
    public bool checkpointReached;
    // Start is called before the first frame update
    void Start()
    {
        checkpointSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            checkpointSpriteRenderer.sprite = yourHouse;
            checkpointReached = true;

        }
    }
}
