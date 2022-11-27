using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    private Rigidbody fruit;
    public bool isGameOver;
    public GameEvent endGame;
    private bool gameAlreadyEnded;

    // Start is called before the first frame update
    void Start()
    {
        fruit = GetComponent<Rigidbody>();
        isGameOver = false;
        gameAlreadyEnded = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            endGame.Raise();
            gameAlreadyEnded = true;
            isGameOver = false;
        }
    }

    public void gameEnds()
    {
        if (!gameAlreadyEnded)
            isGameOver = true;
    }
}