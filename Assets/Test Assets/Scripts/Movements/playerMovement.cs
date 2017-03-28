using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public GameObject feetColl; //Collider that will be at the player's feet

    public Vector3 moveDirection;
    float horiMoveSpeed, vertMoveSpeed, jumpSpeed, gravity, vertPos, landingPos;
	int dirFacing; //Direction character is facing, 1 = right, -1 = left
    public bool jumpState;

	Animator anim; //Controls character animations
    CharacterController controller;

    void Start()
    {
        horiMoveSpeed = 6.0f;
        vertMoveSpeed = 3.0f;
        jumpSpeed = 8.0f;
        gravity = 12.0f;
        moveDirection = Vector3.zero;

        jumpState = false;                   // false = not currently jump
        dirFacing = 1;
		anim = GetComponent<Animator>();    // State = 1 is walking
        controller = GetComponent<CharacterController>();

    }

    void Update()
    {
        // Move Left
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
			//if(feetColl.GetComponent<FeetCollision>().canMove(-horiMoveSpeed, Vector2.left))
            //	GetComponent<Transform>().Translate(new Vector3(-horiMoveSpeed,0,0));
            moveDirection.x = -horiMoveSpeed;
			dirFacing = -1; //Facing Left
            anim.SetInteger("State", 1);
        }

        // Move right
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            //if(feetColl.GetComponent<FeetCollision>().canMove(horiMoveSpeed, Vector2.right))
            //	GetComponent<Transform>().Translate(new Vector3(horiMoveSpeed,0,0));
            moveDirection.x = horiMoveSpeed;
            dirFacing = 1; //Facing Right
            anim.SetInteger("State", 1);
        }

        // No horizontal movement
        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow))
            moveDirection.x = 0;

        // Move "up" i.e. toward background
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumpState == false)
        {
            //if(feetColl.GetComponent<FeetCollision>().canMove(vertMoveSpeed,Vector2.up))
            //	GetComponent<Transform>().Translate(new Vector3(0,vertMoveSpeed,0));
            moveDirection.y = vertMoveSpeed;
            if (jumpState == true)
                landingPos += vertMoveSpeed;
            anim.SetInteger("State", 1);
        }

        // Move "down" i.e. toward foreground
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && jumpState == false)
        {
            //if(feetColl.GetComponent<FeetCollision>().canMove(-vertMoveSpeed,Vector2.down))
            //	GetComponent<Transform>().Translate(0,-vertMoveSpeed,0);
            moveDirection.y = -vertMoveSpeed;
            if (jumpState == true)
                landingPos += -vertMoveSpeed;
            anim.SetInteger("State", 1);
        }

        // No vertical movement
        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && jumpState == false)
            moveDirection.y = 0;

        // Idle animation
        if (moveDirection.x == 0.0f && moveDirection.y == 0.0f)
            anim.SetInteger("State", 0);

		// Direction-facing calculation
		if (dirFacing == -1)
			GetComponent<Transform> ().localScale = new Vector3(-Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value negative
		else
			GetComponent<Transform> ().localScale = new Vector3(Mathf.Abs (GetComponent<Transform> ().localScale.x), GetComponent<Transform> ().localScale.y, GetComponent<Transform> ().localScale.z); //Makes the scale value positive

        // Jump function
        vertPos = GetComponent<Transform>().position.y;
        if (Input.GetKey(KeyCode.Space) && jumpState == false)
        {
                landingPos = vertPos; // Holds value of ground position if jumping
                moveDirection.y = jumpSpeed;
                jumpState = true;
        }
        if (jumpState == true)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            gravity += 0.5f;
        }

        // Apply all movements based on collective key input
        controller.Move(moveDirection * Time.deltaTime);
    }

    // Handles fall of jump
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "footCollider")
        {
            if (moveDirection.y > 0)
            {
                moveDirection.y = 0;
                if (jumpState == true)
                {
                    jumpState = false;
                    gravity = 12.0f;    // Reset jump gravity to base value
                }
            }
        }
    }
		
}
