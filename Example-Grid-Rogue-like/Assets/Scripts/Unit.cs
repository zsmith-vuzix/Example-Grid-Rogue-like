using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int movement;
    public int x;
    public int y;
    public bool playerUnit;
    [SerializeField] public int range;
    [SerializeField] Button wait;
    [SerializeField] Button attack;
    [SerializeField] Button capture;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showMoves(int movesLeft, int x,int y)
    {
        
        if (movesLeft < 0 || x<0 || x> Grid.instance.xMax-1 || y < 0 || y > Grid.instance.yMax-1)
        {
            return;
        }
        Tile current = Grid.instance._tiles[new Vector2(x, y)];
        current._highlight.SetActive(true);
        movesLeft -= current.resistance;
        showMoves(movesLeft, x-1, y);
        showMoves(movesLeft, x+1, y);
        showMoves(movesLeft, x, y-1);
        showMoves(movesLeft, x, y+1);
    }
    public void move(int newX, int newY)
    {
        
        Grid.instance._tiles[new Vector2(x, y)].unit = null;
        Grid.instance._tiles[new Vector2(newX, newY)].unit = this;
        Grid.instance._tiles[new Vector2(newX, newY)].unit.x = newX;
        Grid.instance._tiles[new Vector2(newX, newY)].unit.y = newY;
        this.transform.position = new Vector2(newX, newY);
    }
    public void showActions()
    {
        Tile currentTile = Grid.instance._tiles[new Vector2(x, y)];
        wait.transform.position = new Vector2(50, 50);
        wait.gameObject.SetActive(true);
        if (EnemyInRange(range ,x, y))
        {
            attack.transform.position = new Vector2(x, y);
            attack.gameObject.SetActive(true);
        }

        if ( currentTile.building != null && currentTile.building.owner!= BuildingState.Player)
        {
            capture.transform.position = new Vector2(x, y);
            capture.gameObject.SetActive(true);
        }
    }

    public void clearActions()
    {
        wait.gameObject.SetActive(false);
        attack.gameObject.SetActive(false);
        capture.gameObject.SetActive(false);
    }

    public bool EnemyInRange(int rangeLeft, int x, int y)
    {
        if (rangeLeft < 0 || x < 0 || x > Grid.instance.xMax - 1 || y < 0 || y > Grid.instance.yMax - 1)
        {
            return false;
        }

        Tile current = Grid.instance._tiles[new Vector2(x, y)];
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
