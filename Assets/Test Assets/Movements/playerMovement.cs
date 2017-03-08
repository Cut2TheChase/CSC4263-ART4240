using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

    public GameObject player;
	public GameObject feetColl; //Collider that will be at the player's feet
    //float vertLimitUp, vertLimitDown;

    Vector3 vertMoveSpeed, horiMoveSpeed;
    Vector4 jumpSpeed;
    float vertPos;
    bool jumpState;

    void Start()
    {
        vertMoveSpeed = new Vector3(0, 0.03f, 0);
        horiMoveSpeed = new Vector3(0.06f, 0, 0);
        jumpSpeed = new Vector4(0,0.0008f,0,Time.deltaTime * 10);

        // Need to write getters and setters for these
        //vertLimitUp = 0.5f;
        //vertLimitDown = -3.5f;

        jumpState = false;
    }

    void Update()
    {
        // Updates current position
        vertPos = player.GetComponent<Transform>().position.y;
        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(-horiMoveSpeed) == true)
            	player.GetComponent<Transform>().Translate(-horiMoveSpeed);
            // TBD: Animation, i.e. sprite change
            //  Possibly use global counter variable to pace out animation?
        }

        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(horiMoveSpeed) == true)
            	player.GetComponent<Transform>().Translate(horiMoveSpeed);
            // TBD: Animation, i.e. sprite change
        }

        // Move "up" i.e. toward background
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) /*&& vertPos <= vertLimitUp*/ && jumpState == false)
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(vertMoveSpeed))
            	player.GetComponent<Transform>().Translate(vertMoveSpeed);
            // TBD: Animation, i.e. sprite change
        }

        // Move "down" i.e. toward foreground
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) /*&& vertPos >= vertLimitDown*/ && jumpState == false)
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(-vertMoveSpeed))
            	player.GetComponent<Transform>().Translate(-vertMoveSpeed);
            // TBD: Animation, i.e. sprite change
        }

        // Jump function
        // Does not currently work; considering using Unity's built-in gravity and physics
        // Implementation idea: Create a "floor" platform that follows player's feet
        //                      Platform does not interact with any other objects
        //                      Will need consideration for jumping to different heights in platforms

        /*if (Input.GetKey(KeyCode.Space) && jumpState == false)
        {
            jumpState = true;
            float jumpStart = vertPos;
            float jumpPeak = vertPos + 2.5f;

            // TBD: Animation, i.e. sprite change

            while (player.GetComponent<Transform>().position.y < jumpPeak)
            {
                player.GetComponent<Transform>().Translate(jumpSpeed);
            }

            while (player.GetComponent<Transform>().position.y > jumpStart)
            {
                player.GetComponent<Transform>().Translate(-jumpSpeed);
            }

            jumpState = false;
        }*/
    }
    // Setters and Getters for stage movement constraints.
    // Considering adding horizontal limiters?
	/*
    public void setVertLimitUp(float newLim)
    {
        vertLimitUp = newLim;
    }

    public void setVertLimitDown(float newLim)
    {
        vertLimitDown = newLim;
    }

    public float getVertLimitUp()
    {
        return vertLimitUp;
    }

    public float getVertLimitDown()
    {
        return vertLimitDown;
    }
    */
}
