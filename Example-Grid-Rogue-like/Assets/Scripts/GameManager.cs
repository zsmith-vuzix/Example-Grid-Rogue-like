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

    //TODO
    //different prefab implementation
    [SerializeField] public Tile defaultTile1;
    [SerializeField] public Tile defaultTile2;
    [SerializeField] public Unit infantry;
    [SerializeField] public Unit infantryEnemy;
    [SerializeField] public Building defaultBuilding;

    [SerializeField] public Grid grid;

    //UI
    [SerializeField] public TMP_Text playerMoney;
    [SerializeField] public UnityEngine.UI.Button endTurn;
    [SerializeField] public UnityEngine.UI.Button wait;
    [SerializeField] public UnityEngine.UI.Button attack;
    [SerializeField] public UnityEngine.UI.Button capture;

    //State
    public GameState state;
    public Unit selectedUnit;
    public bool attacking = false;
    public bool moving = false;

    //TODO
    //Should be a seperate player
    public int enemyMoney;
    public int enemyIncome;
    public Building[] enemybuildings;

    public static event Action<GameState> OnGameStateChanged;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.GenerateBoard);
    }

    //TODO
    //Replace placeholder methods
    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.GenerateBoard:
                grid.BuildBoard();
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
        //Income
        Player.instance.money += (Player.instance.income + Player.instance.buildings.Length);
        playerMoney.text = "$" + Player.instance.money.ToString();
        //Allow end turn button
        endTurn.gameObject.SetActive(true);
    }

    //End turn button
    public void EndTurn()
    {
        endTurn.gameObject.SetActive(false);
        UpdateGameState(GameState.EnemeyTurn);
    }

    //Wait button
    public void Wait()
    {
        clearActions();
    }

    //Attack button
    public void Attack()
    {
        attacking = true;

    }

    //Capture button
    public void Capture()
    {
        endTurn.gameObject.SetActive(false);
        UpdateGameState(GameState.EnemeyTurn);
    }

    public void clearActions()
    {
        wait.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        capture.gameObject.SetActive(false);
        Grid.instance.UnhighlightAll();
        attacking = false;
        selectedUnit = null;
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