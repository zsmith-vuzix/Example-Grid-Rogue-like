using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject _highlight;
    // Start is called before the first frame update
    public Unit unit;
    public Building building;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
    private void OnMouseUp()
    {
        if (GameManager.instance.state == GameState.PlayerTurn)
            return;
        if (unit != null)
        {
            unit.showMoves();
        }
        else if (building != null)
        {
            building.showBuildable();
        }
    }
}
