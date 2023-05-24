using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int movement;
    public int x;
    public int y;
    
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
        this.transform.position = new Vector2(newX, newY);
    }
}
