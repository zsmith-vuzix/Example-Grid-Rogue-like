using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance;
    public int xMax;
    public int yMax;
    public Dictionary<Vector2, Tile> _tiles;

    private void Awake()
    {
        instance = this;
        _tiles = new Dictionary<Vector2, Tile>();
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
                _tiles[new Vector2(x, y)] = current;
            }
        }
    }
    public void AddUnit(Vector2 xy, Unit unit)
    {
        unit.x = (int)xy.x;
        unit.y = (int)xy.y;
        _tiles[xy].unit = Instantiate(unit, new Vector3(xy.x, xy.y), Quaternion.identity);
    }
    public void AddBuilding(Vector2 xy, Building building, BuildingState state)
    {
        building.x = (int)xy.x;
        building.y = (int)xy.y;
        building.owner = state;
        _tiles[xy].building = Instantiate(building, new Vector3(xy.x, xy.y), Quaternion.identity);

    }

    public void BuildBoard()
    {
        //TODO Case for each level
        BaseGrid(8, 8, GameManager.instance.defaultTile1, GameManager.instance.defaultTile2);
        Grid.instance.AddBuilding(new Vector2(1, 1), GameManager.instance.defaultBuilding, BuildingState.Player);
        Grid.instance.AddUnit(new Vector2(2, 2), GameManager.instance.infantry);

        GameManager.instance.cam.transform.position = new Vector3((float) Grid.instance.xMax/2 -0.5f, (float)Grid.instance.yMax / 2 - 0.5f, -10);
        GameManager.instance.UpdateGameState(GameState.PlayerTurn);
    }
    public void UnhighlightAll()
    {
        foreach (Tile tile in _tiles.Values)
        {
            tile._highlight.SetActive(false);
        }
    }
}
