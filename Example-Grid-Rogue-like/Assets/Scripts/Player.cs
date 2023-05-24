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

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        income = 1;
        movementModifier = 0;
        captureModifier = 0;
        money = 0;
        buildings = new Building[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
