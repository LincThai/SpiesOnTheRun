﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.preGame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public enum GameState { preGame, game, dead};