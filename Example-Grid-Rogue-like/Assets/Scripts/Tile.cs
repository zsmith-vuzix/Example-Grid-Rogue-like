using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public GameObject _highlight;
    // Start is called before the first frame update
    public Unit unit;
    public Building building;
    public int resistance;
    public int x;
    public int y;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseEnter()
    {
        if (GameManager.instance.selectedUnit == null)
        {
            _highlight.SetActive(true);
        }
    }
    private void OnMouseExit()
    {
        if (GameManager.instance.selectedUnit == null)
        {
            _highlight.SetActive(false);
        }

    }
    private void OnMouseUp()
    {
        if (GameManager.instance.state != GameState.PlayerTurn)
            return;
        else if (GameManager.instance.selectedUnit != null && _highlight.activeSelf)
        {
            GameManager.instance.selectedUnit.move(x, y);
            Grid.instance.UnhighlightAll();
            GameManager.instance.selectedUnit.showActions();
            GameManager.instance.selectedUnit = null;
        }
        else if (unit != null && GameManager.instance.selectedUnit == null)
        {
            unit.showMoves(unit.movement, x, y);
            GameManager.instance.selectedUnit = unit;

        }
        else if (building != null && building.owner == BuildingState.Player)
        {
            building.showBuildable();
        }
        else if (GameManager.instance.attacking)
        {

        }
    }
}
