using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] Tile defaultTile1;
    [SerializeField] Tile defaultTile2;
    [SerializeField] Building defaultBuilding;
    // Start is called before the first frame update
    void Start()
    {
        Grid grid = new Grid(3, 3, defaultTile1,defaultTile2);
        grid.AddBuilding(new Vector2(1, 1), defaultBuilding);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
