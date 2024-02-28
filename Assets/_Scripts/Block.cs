using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public int hitsToDestroy = 1;

    public int points;

    private int numberOfHits;

    private GameController gameController;

    private void Awake()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
    }

    private void Start()
    {
        numberOfHits = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            numberOfHits++;

            if (numberOfHits >= hitsToDestroy)
            {
                gameController.AddPoints(points);
                Destroy(this.gameObject);
            }
        }
    }
}
