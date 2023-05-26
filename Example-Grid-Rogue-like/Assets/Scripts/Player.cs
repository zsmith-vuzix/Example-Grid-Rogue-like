using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public int income;
    public int movementModifier;
    public int captureModifier;
    public int money;
    public Building[] buildings;
    public Unit[] units;

    private void Awake()
    {
        instance = this;
        income = 1;
        movementModifier = 0;
        captureModifier = 0;
        money = 0;
        buildings = new Building[0];
        units = new Unit[0];
    }

    public void RefreshUnits()
    {
        foreach (Unit unit in units)
        {
            unit.ready = true;
        }
    }
}
