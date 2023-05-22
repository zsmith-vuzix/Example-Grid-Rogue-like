using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] GameObject _highlight;
    // Start is called before the first frame update
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
}
