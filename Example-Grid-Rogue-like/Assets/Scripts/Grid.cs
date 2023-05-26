using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance;
    public int xMax;
    public int yMax;
    public Dictionary<Vector2, Tile> tiles;

    private void Awake()
    {
        instance = this;
        tiles = new Dictionary<Vector2, Tile>();
    }

    public void BaseGrid(int x, int y, Tile defaultTile1, Tile defaultTile2)
    {
        this.xMax = x;
        this.yMax = y;
        Tile current;
        for (x = 0; x < xMax; x++)
        {
            for (y = 0; y < yMax; y++)
            {
                if (x%2 != y % 2)
                {
                    current = Instantiate(defaultTile1, new Vector3(x, y), Quaternion.identity);
                }
                else
                {
                    current = Instantiate(defaultTile2, new Vector3(x, y), Quaternion.identity);
                }
                current.name = $"Tile {x} {y}";
                current.x = x;
                current.y = y;
                tiles[new Vector2(x, y)] = current;
            }
        }
    }
    public void AddUnit(Vector2 xy, Unit unit)
    {
        unit.x = (int)xy.x;
        unit.y = (int)xy.y;
        tiles[xy].unit = Instantiate(unit, new Vector3(xy.x, xy.y), Quaternion.identity);
    }
    public void AddBuilding(Vector2 xy, Building building, BuildingState state)
    {
        building.x = (int)xy.x;
        building.y = (int)xy.y;
        building.owner = state;
        tiles[xy].building = Instantiate(building, new Vector3(xy.x, xy.y), Quaternion.identity);

    }

    public void BuildLevel(int level)
    {
        //TODO functionality for different levels
        switch (level)
        {
            case 1:
                BaseGrid(8, 8, GameManager.instance.defaultTile1, GameManager.instance.defaultTile2);
                instance.AddBuilding(new Vector2(1, 1), GameManager.instance.defaultBuilding, BuildingState.Player);
                instance.AddUnit(new Vector2(5, 5), GameManager.instance.infantry);
                instance.AddUnit(new Vector2(7, 7), GameManager.instance.infantryEnemy);
                instance.AddUnit(new Vector2(6, 6), GameManager.instance.infantryEnemy);

                GameManager.instance.cam.transform.position = new Vector3((float)xMax / 2 - 0.5f, (float)yMax / 2 - 0.5f, -10);
                GameManager.instance.UpdateGameState(GameState.PlayerTurn);
                break;
        }

    }
    public void UnhighlightAll()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile._highlight.SetActive(false);
        }
    }
}
