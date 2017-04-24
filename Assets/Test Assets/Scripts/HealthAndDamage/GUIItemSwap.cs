///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the GUI for switching between game items.
///Author -- Mitchell Aucoin
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIItemSwap : MonoBehaviour {
    //the script is atatched to the GUI of one item this refers to the GUI of the other item
    public GameObject other;
    //calls the swap function when E key is pressed
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Swap();
        }
    }
    //the swap function handles swaping the positions and layers of the two GUI Items
    void Swap()
    {
        //handles the positions
        Vector3 temp = transform.position;
        transform.position = other.transform.position;
        other.transform.position = temp;
        //handles the layers
        int index = transform.GetSiblingIndex();
        int index2 = other.transform.GetSiblingIndex();
        transform.SetSiblingIndex(index2);
        other.transform.SetSiblingIndex(index);
    }
}
