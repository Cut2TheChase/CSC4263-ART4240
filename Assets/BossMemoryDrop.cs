///Uptown Pigeon Gaming
///Project Fugue
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- Moves memory on boss death to reachable location
///Author -- Jonathan Nguyen
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMemoryDrop : MonoBehaviour
{
    public Transform target;    // Target location for memory to move to
    Transform memTransform;
    bool bossDeath;             // Used both to indicate when the memory should start and stop moving
    float memSpeed;

    void Start()
    {
        bossDeath = false;
        memSpeed = 3;
        memTransform = this.gameObject.GetComponent<Transform>();
    }

    void Update()
    {
        if (bossDeath == true)
        {
            float step = memSpeed * Time.deltaTime;
            memTransform.position = Vector3.MoveTowards(memTransform.position, target.position, step);
            if (memTransform.position == target.position)
                bossDeath = false;
        }
    }

    public void jump()
    {
        bossDeath = true;
    }

}
