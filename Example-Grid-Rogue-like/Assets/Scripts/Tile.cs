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
        //Not your turn: do nothing
        if (GameManager.instance.state != GameState.PlayerTurn)
            return;
        //Unit is already selected: move it
        else if (GameManager.instance.selectedUnit != null && _highlight.activeSelf && !GameManager.instance.attacking) //highligted means it was a square the unit can move to
        {
            GameManager.instance.selectedUnit.move(x, y);
            Grid.instance.UnhighlightAll();
            GameManager.instance.selectedUnit.showActions();
            GameManager.instance.selectedUnit = null;
        }
        //Unit is not selected: select it
        else if (unit != null && GameManager.instance.selectedUnit == null && unit.playerUnit)
        {
            unit.showMoves(unit.movement, x, y);
            GameManager.instance.selectedUnit = unit;

        }
        //Building you own is selected: show options
        else if (building != null && building.owner == BuildingState.Player)
        {
            building.showBuildable();
        }
        //Attack button was selected: attack the enemy unit
        else if (GameManager.instance.attacking && !(this.unit == null) && !this.unit.playerUnit)
        {
            GameManager.instance.selectedUnit.attackUnit(this.unit);
            GameManager.instance.clearActions();
        }
    }
}
