using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // game state
    gameState gameState = gameState.menu;

    [SerializeField]
    GameObject mapa;
    public float mapLevel { get; private set; }

    void Awake()
    {
        mapLevel = mapa.transform.position.y;
    }

    public void ChangeGameState(gameState state)
    {
        gameState = state;
    }
}

public enum gameState
{
    menu, shop, game
}