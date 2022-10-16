using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public int id;
    public bool taken = false;

    GridSystem gridSystem;
    // Start is called before the first frame update
    void Start()
    {
        gridSystem = GetComponentInParent<GridSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetId(int i)
    {
        id = i;
    }

    public void SetValue(bool isHolding)
    {
        taken = isHolding;
        gridSystem.CheckValues();
    }

}
