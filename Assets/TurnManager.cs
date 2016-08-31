using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {

    public CellGrid CellGrid;

    // Use this for initialization
    void Start () {
	
	}

    // Update is called once per frame


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            //User ends his turn by pressing "n" on keyboard.
            CellGrid.EndTurn();
        }
    }
} 
