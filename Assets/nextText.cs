///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- Holds a reference, if any, to the proceeding text for a cutscene event. Also hides cutscene text on the Canvas by default.
///Author -- Jonathan Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextText : MonoBehaviour
{
    public UnityEngine.UI.Text next;
    
    void Start()
    {
        gameObject.gameObject.SetActive(false);
    }
}
