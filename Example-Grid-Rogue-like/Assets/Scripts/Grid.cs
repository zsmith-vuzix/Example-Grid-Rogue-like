using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int _x;
    public int _y;
    public Dictionary<Vector2, Tile> _tiles;
    public Grid(int x, int y, Tile defaultTile1, Tile defaultTile2)
    {
        _x = x;
        _y = y;
        _tiles = new Dictionary<Vector2, Tile>();
        Tile current;
        for (int xTemp = 0; xTemp < _x; xTemp++)
        {
            for (int yTemp = 0; yTemp < _y; yTemp++)
            {
                if (xTemp%2 != yTemp % 2)
                {
                    current = Instantiate(defaultTile1, new Vector3(xTemp, yTemp), Quaternion.identity);
                }
                else
                {
                    current = Instantiate(defaultTile2, new Vector3(xTemp, yTemp), Quaternion.identity);
                }
                current.name = $"Tile {xTemp} {yTemp}";
                _tiles[new Vector2(xTemp, yTemp)] = current;
            }
        }
    }
    public void AddUnit(Vector2 xy, Unit unit)
    {
        _tiles[xy].unit = unit;
    }
    public void AddBuilding(Vector2 xy, Building building)
    {
        _tiles[xy].building = Instantiate(building, new Vector3(xy.x, xy.y), Quaternion.identity);
    }
}
