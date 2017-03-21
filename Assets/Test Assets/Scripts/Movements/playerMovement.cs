﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{

	public GameObject feetColl; //Collider that will be at the player's feet


    Vector3 vertMoveSpeed, horiMoveSpeed;
    Vector4 jumpSpeed;
	int dirFacing = 1; //Direction character is facing, 1 = right, -1 = left
    bool jumpState;

	Animator anim; //Controls character animations

    void Start()
    {
        vertMoveSpeed = new Vector3(0, 0.03f, 0);
        horiMoveSpeed = new Vector3(0.06f, 0, 0);
        jumpSpeed = new Vector4(0,0.0008f,0,Time.deltaTime * 10);

        jumpState = false;

		anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(-horiMoveSpeed, Vector2.left))
            	GetComponent<Transform>().Translate(-horiMoveSpeed);

			dirFacing = -1; //Facing Left
			anim.SetInteger("State", 1); //Changes animation state to Walking

        }

        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(horiMoveSpeed, Vector2.right))
            	GetComponent<Transform>().Translate(horiMoveSpeed);

			dirFacing = 1; //Facing Right
			anim.SetInteger("State", 1); //Changes animation state to Walking
        }

        // Move "up" i.e. toward background
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumpState == false)
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(vertMoveSpeed,Vector2.up))
            	GetComponent<Transform>().Translate(vertMoveSpeed);

			anim.SetInteger("State", 1); //Changes animation state to Walking
        }

        // Move "down" i.e. toward foreground
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && jumpState == false)
        {
			if(feetColl.GetComponent<FeetCollision>().canMove(-vertMoveSpeed,Vector2.down))
            	GetComponent<Transform>().Translate(-vertMoveSpeed);

			anim.SetInteger("State", 1); //Changes animation state to Walking
        }

		//Handles idle animation
		if (!Input.GetKey (KeyCode.W) && !Input.GetKey (KeyCode.UpArrow) && !Input.GetKey (KeyCode.S) && !Input.GetKey (KeyCode.DownArrow)
		   && !Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.RightArrow) && !Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.LeftArrow))
				anim.SetInteger ("State", 0); //changes animation state to Idle
		
		//Direction facing calculation
		if (dirFacing == -1)
			GetComponent<Transform> ().localScale = new Vector3(-Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value negative
		else
			GetComponent<Transform> ().localScale = new Vector3(Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value positive

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
}