using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public Tile defaultTile1;
    [SerializeField] public Tile defaultTile2;
    [SerializeField] public Building defaultBuilding;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateGameState(GameState.GenerateBoard);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateGameState(GameState newState)
    {
        State = newState;
        switch (newState)
        {
            case GameState.GenerateBoard:
                break;
            case GameState.PlayerTurn:
                break;
            case GameState.EnemeyTurn:
                break;
            case GameState.RoundOver:
                break;
            case GameState.GameOver:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
}
public enum GameState
{
    GenerateBoard,
    PlayerTurn,
    EnemeyTurn,
    RoundOver,
    GameOver
}