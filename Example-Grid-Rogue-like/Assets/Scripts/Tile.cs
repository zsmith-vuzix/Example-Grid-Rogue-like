using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public GameObject _highlight;
    public Unit unit;
    public Building building;
    public int resistance;
    public int x;
    public int y;

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
        //Do nothing if it is not your turn
        if (GameManager.instance.state != GameState.PlayerTurn)
            return;
        //move and show actions if a unit is already selected
        else if (GameManager.instance.selectedUnit != null && _highlight.activeSelf) //highligted means it was a square the unit can move to
        {
            GameManager.instance.selectedUnit.move(x, y);
            Grid.instance.UnhighlightAll();
            GameManager.instance.selectedUnit.showActions();
            //GameManager.instance.selectedUnit = null;
        }
        //select a unit if one is not already selected
        else if (unit != null && GameManager.instance.selectedUnit == null && unit.playerUnit)
        {
            unit.showMoves(unit.movement, x, y);
            GameManager.instance.selectedUnit = unit;

        }
        //if a building is selected show unit options
        else if (building != null && building.owner == BuildingState.Player)
        {
            building.showBuildable();
        }
        //if the attack action was previously selected attack this enemy unit
        else if (GameManager.instance.attacking && !this.unit.playerUnit)
        {

        }
    }
}
