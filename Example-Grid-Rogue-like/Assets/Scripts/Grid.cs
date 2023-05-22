using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public int _x;
    public int _y;
    private Tile[,] Tiles;
    public Grid(int x, int y, Tile defaultTile1, Tile defaultTile2)
    {
        _x = x;
        _y = y;
        for (int xTemp = 0; xTemp < _x; xTemp++)
        {
            for (int yTemp = 0; yTemp < _y; yTemp++)
            {
                if (xTemp%2 != yTemp % 2)
                {
                    Tiles[xTemp, yTemp] = defaultTile1;
                }
                else
                {
                    Tiles[xTemp, yTemp] = defaultTile2;
                }


            }
        }
    }
}
