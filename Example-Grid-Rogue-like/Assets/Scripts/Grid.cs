using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int _x;
    public int _y;
    public Grid(int x, int y, Tile defaultTile1, Tile defaultTile2)
    {
        _x = x;
        _y = y;
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
            }
        }
    }
}
