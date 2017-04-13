using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIItemSwap : MonoBehaviour {

    public GameObject other;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Swap();
        }
    }

    void Swap()
    {
        Vector3 temp = transform.position;
        transform.position = other.transform.position;
        other.transform.position = temp;
        int index = transform.GetSiblingIndex();
        int index2 = other.transform.GetSiblingIndex();
        transform.SetSiblingIndex(index2);
        other.transform.SetSiblingIndex(index);
    }
}
