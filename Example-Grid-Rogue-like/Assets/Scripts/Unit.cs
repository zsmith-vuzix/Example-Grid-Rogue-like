using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int range;
    public int movement;
    public int x;
    public int y;
    public bool playerUnit;

    public void showMoves(int movesLeft, int x,int y)
    {
        //If no moves left or invalid coordinates do nothing
        if (movesLeft < 0 || x<0 || x> Grid.instance.xMax-1 || y < 0 || y > Grid.instance.yMax-1)
        {
            return;
        }
        //else highligh this tile and check all neighbors
        Tile current = Grid.instance.tiles[new Vector2(x, y)];
        current._highlight.SetActive(true);
        movesLeft -= current.resistance;
        showMoves(movesLeft, x-1, y);
        showMoves(movesLeft, x+1, y);
        showMoves(movesLeft, x, y-1);
        showMoves(movesLeft, x, y+1);
    }
    public void move(int newX, int newY)
    {
        Grid.instance.tiles[new Vector2(x, y)].unit = null;
        Vector2 newXY = new Vector2(newX, newY);
        Tile currentTile = Grid.instance.tiles[newXY];
        currentTile.unit = this;
        currentTile.unit.x = newX;
        currentTile.unit.y = newY;
        this.transform.position = newXY;
    }
    public void showActions()
    {
        //can always wait
        Tile currentTile = Grid.instance.tiles[new Vector2(x, y)];
        GameManager.instance.wait.gameObject.SetActive(true);
        //Can attack?
        if (EnemyInRange(range ,x, y))
        {
            GameManager.instance.attack.gameObject.SetActive(true);
        }
        //Can capture?
        if ( currentTile.building != null && currentTile.building.owner!= BuildingState.Player)
        {
            GameManager.instance.capture.gameObject.SetActive(true);
        }
    }

    public bool EnemyInRange(int rangeLeft, int x, int y)
    {
        if (rangeLeft < 0 || x < 0 || x > Grid.instance.xMax - 1 || y < 0 || y > Grid.instance.yMax - 1)
        {
            return false;
        }

        Tile current = Grid.instance.tiles[new Vector2(x, y)];
        Unit unit =current.unit;

        if (unit != null && unit.playerUnit == false)
        {
            current._highlight.SetActive(true);
        }

        rangeLeft --;
        bool left = EnemyInRange(rangeLeft, x - 1, y);
        bool right = EnemyInRange(rangeLeft, x + 1, y);
        bool down = EnemyInRange(rangeLeft, x, y - 1);
        bool up = EnemyInRange(rangeLeft, x, y + 1);
        return left || right || down || up;
    }
    public void attackUnit()
    {

    }
}
