using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int health;
    public int damage;
    public int range;
    public int movement;
    public int x;
    public int y;
    public bool playerUnit;

    public void showMoves(int movesLeft, int tempX,int tempY)
    {
        //If no moves left or invalid coordinates do nothing
        if (movesLeft < 0 || tempX<0 || tempX> Grid.instance.xMax-1 || tempY < 0 || tempY > Grid.instance.yMax-1 )//|| !Grid.instance.tiles[new Vector2(tempX,tempY)].unit.playerUnit)
        {
            return;
        }
        //else highligh this tile and check all neighbors
        Tile current = Grid.instance.tiles[new Vector2(tempX, tempY)];
        current._highlight.SetActive(true);
        movesLeft -= current.resistance;
        showMoves(movesLeft, tempX-1, tempY);
        showMoves(movesLeft, tempX+1, tempY);
        showMoves(movesLeft, tempX, tempY-1);
        showMoves(movesLeft, tempX, tempY+1);
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

    public bool EnemyInRange(int rangeLeft, int attackX, int attackY)
    {
        bool here = false;
        if (rangeLeft < 0 || attackX < 0 || attackX > Grid.instance.xMax - 1 || attackY < 0 || attackY > Grid.instance.yMax - 1)
        {
            return false;
        }
        
        Tile current = Grid.instance.tiles[new Vector2(attackX, attackY)];
        Unit unit =current.unit;

        if (unit != null && unit.playerUnit == false)
        {
            current._highlight.SetActive(true);
            here = true;
        }

        rangeLeft --;
        bool left = EnemyInRange(rangeLeft, attackX - 1, attackY);
        bool right = EnemyInRange(rangeLeft, attackX + 1, attackY);
        bool down = EnemyInRange(rangeLeft, attackX, attackY - 1);
        bool up = EnemyInRange(rangeLeft, attackX, attackY + 1);
        return left || right || down || up || here;
    }
    public void attackUnit(Unit enemy)
    {
        enemy.health -= damage;
        if (enemy.health <= 0)
        {
            Kill(enemy);
        }
    }
    public void Kill(Unit dead)
    {
        Grid.instance.tiles[new Vector2(dead.x, dead.y)].unit.gameObject.SetActive(false);
        Grid.instance.tiles[new Vector2(dead.x, dead.y)].unit = null;

        Destroy(dead);
    }
}
