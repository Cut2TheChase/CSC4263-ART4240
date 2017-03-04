using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public GameObject player;
    public float vertLimitUp, vertLimitDown;

    Vector3 vertMoveSpeed = new Vector3(0, 0.03f, 0);
    Vector3 horiMoveSpeed = new Vector3(0.06f, 0, 0);
    float vertPos;

    void Start()
    {
        // Made public so can be adjusted by other scripts as needed. Below are default limits
        vertLimitUp = 0.5f;
        vertLimitDown = -3.5f;
    }

    void Update()
    {
        // Updates current position
        vertPos = player.GetComponent<Transform>().position.y;

        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            player.GetComponent<Transform>().Translate(-horiMoveSpeed);
            // TBD: Animation, i.e. sprite change
            //  Possibly use global counter variable to pace out animation?
        }

        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            player.GetComponent<Transform>().Translate(horiMoveSpeed);
            // TBD: Animation, i.e. sprite change
        }

        // Move "up" i.e. toward background
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && vertPos <= vertLimitUp)
        {
            player.GetComponent<Transform>().Translate(vertMoveSpeed);
            // TBD: Animation, i.e. sprite change
        }

        // Move "down" i.e. toward foreground
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && vertPos >= vertLimitDown)
        {
            player.GetComponent<Transform>().Translate(-vertMoveSpeed);
            // TBD: Animation, i.e. sprite change
        }

        // Jump, TBD
    }
}
