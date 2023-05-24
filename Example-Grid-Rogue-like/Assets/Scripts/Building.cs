using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public Dictionary<string, int> _buildable;
    public int x;
    public int y;
    public BuildingState owner;
    // Start is called before the first frame update
    void Start()
    {
        _buildable = new Dictionary<string, int>();
        _buildable["infantry"] = 1000;
        _buildable["tank"] = 10000;
        owner = BuildingState.Nuetral;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void showBuildable()
    {

    }
}
public enum BuildingState
{
    Player,
    Enemy,
    Nuetral
}
