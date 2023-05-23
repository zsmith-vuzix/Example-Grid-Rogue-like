using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public Transform cam;
    [SerializeField] public Tile defaultTile1;
    [SerializeField] public Tile defaultTile2;
    [SerializeField] public Unit infantry;
    [SerializeField] public Building defaultBuilding;
    [SerializeField] public Grid grid;
    [SerializeField] public TMP_Dropdown unitActions;
    [SerializeField] public TMP_Dropdown buildingOptions;
    [SerializeField] public UnityEngine.UI.Button endTurn;
    public GameState state;
    public bool unitSelected = false;

    public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        instance = this;
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
        state = newState;
        switch (newState)
        {
            case GameState.GenerateBoard:
                GenerateBoard();
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
    }

    private void GenerateBoard()
    {
        grid.BuildBoard();
    }

    private void ShowGameOverScreen()
    {
        //TODO
        throw new NotImplementedException();
    }

    private void ShowRoundOverScreen()
    {
        //TODO
        throw new NotImplementedException();
    }

    private void HandleEnemyTurn()
    {
        //TODO
        throw new NotImplementedException();
    }

    private void HandlePlayerTurn()
    {
        endTurn.gameObject.SetActive(true);
    }
    public void showUnitMovement(Unit unit)
    {

    }
    public void showUnitActions()
    {

    }
    public void ShowBuildingOptions()
    {

    }
    public void EndTurn()
    {
        endTurn.gameObject.SetActive(false);
        UpdateGameState(GameState.EnemeyTurn);
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