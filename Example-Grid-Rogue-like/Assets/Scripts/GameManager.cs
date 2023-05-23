using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] public Transform cam;
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
                HandlePlayerTurn();
                break;
            case GameState.EnemeyTurn:
                HandleEnemyTurn();
                break;
            case GameState.RoundOver:
                ShowRoundOverScreen();
                break;
            case GameState.GameOver:
                ShowGameOverScreen();
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void ShowGameOverScreen()
    {
        throw new NotImplementedException();
    }

    private void ShowRoundOverScreen()
    {
        throw new NotImplementedException();
    }

    private void HandleEnemyTurn()
    {
        throw new NotImplementedException();
    }

    private void HandlePlayerTurn()
    {
        throw new NotImplementedException();
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