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
    [SerializeField] public UnityEngine.UI.Dropdown purchaseUnits;

    //State
    public GameState state;
    public Unit selectedUnit;
    public bool attacking = false;
    public bool moving = false;
    public int level;
    //TODO
    //Should be a seperate player
    public int enemyMoney;
    public int enemyIncome;
    public Building[] enemybuildings;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.MainMenu);
    }

    public void UpdateGameState(GameState newState)
    {
        state = newState;
        switch (newState)
        {
            case GameState.MainMenu:
                //TODO
                UpdateGameState(GameState.GameMenu);
                break;
            case GameState.GameMenu:
                //TODO
                level = 1;
                UpdateGameState(GameState.GenerateLevel);
                break;
            case GameState.GenerateLevel:
                grid.BuildLevel(level);
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
        Player.instance.RefreshUnits();
        Player.instance.money += (Player.instance.income + Player.instance.buildings.Length);
        playerMoney.text = "$" + Player.instance.money.ToString();
        endTurn.gameObject.SetActive(true);
    }

    public void EndTurn()
    {
        endTurn.gameObject.SetActive(false);
        UpdateGameState(GameState.EnemeyTurn);
    }

    public void Wait()
    {
        ClearActions();
    }

    public void Attack()
    {
        attacking = true;
        wait.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        capture.gameObject.SetActive(false);
    }

    public void Capture()
    {
        selectedUnit.Capture();
        ClearActions();
    }

    public void ClearActions()
    {
        wait.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        capture.gameObject.SetActive(false);
        attacking = false;
        selectedUnit = null;
        Grid.instance.UnhighlightAll();
    }
}

public enum GameState
{
    MainMenu,
    GameMenu,
    GenerateLevel,
    PlayerTurn,
    EnemeyTurn,
    RoundOver,
    GameOver
}