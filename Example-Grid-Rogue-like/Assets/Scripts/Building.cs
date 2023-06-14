using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Dropdown;

public class Building : MonoBehaviour
{
    public Dictionary<string, int> _buildable;
    public int x;
    public int y;
    public BuildingState owner;
    public int captureHealth;
    // Start is called before the first frame update
    void Start()
    {
        _buildable = new Dictionary<string, int>();
        _buildable["infantry"] = 1000;
        _buildable["tank"] = 10000;
        owner = BuildingState.Nuetral;
        captureHealth = 20;
    }

    //TODO
    public void showBuildable()
    {
       List<string> options = new List<string>();
        options.Add("Infantry: 1000");
        options.Add("Tank:     10000");
        GameManager.instance.purchaseUnits.AddOptions(options);
        GameManager.instance.purchaseUnits.gameObject.SetActive(true);
    }
}
public enum BuildingState
{
    Player,
    Enemy,
    Nuetral
}
