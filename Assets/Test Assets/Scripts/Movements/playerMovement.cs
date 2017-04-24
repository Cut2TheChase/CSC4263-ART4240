///Uptown Pigeon Gaming
///Project Fuge
///CSC4263-ART4240
///Dr. Robert Kooima
///Code Description -- A code that manages the movement of the character in a 2.5d world.
///Author -- Chase Bernard, Jonathan Nguyen
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

	[HideInInspector]
	public bool notHooked = true;
	[HideInInspector]
	public bool canMoveX = true;
	[HideInInspector]
	public bool canMoveY = true;
	public swing right;
	public swing left;

	private bool jump_active;

	[HideInInspector]
	public bool attacking = false;
	[HideInInspector]
	public int attackState = 2;

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
		feetColl = GameObject.FindGameObjectWithTag ("Feet Collider");



    }

    void Update()
    {
		if (notHooked == false)
			canMoveX = false;



		if (notHooked == true) {
			
			// Move Left
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) {
				if (feetColl.GetComponent<FeetCollision> ().canMove (-horiMoveSpeed, Vector2.left)) {
					moveDirection.x = -horiMoveSpeed;
					dirFacing = -1; //Facing Left
					anim.SetInteger ("State", 1);
					canMoveX = true;
				} else
					canMoveX = false;
			}

        // Move right
			else if (Input.GetKey (KeyCode.D) && notHooked == true || Input.GetKey (KeyCode.RightArrow) && notHooked == true) {
				if (feetColl.GetComponent<FeetCollision> ().canMove (horiMoveSpeed, Vector2.right)) {
					moveDirection.x = horiMoveSpeed;
					dirFacing = 1; //Facing Right
					anim.SetInteger ("State", 1);
					canMoveX = true;
				} else
					canMoveX = false;
			}
		}
        // No horizontal movement
		if ((!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow)) || canMoveX == false)
            moveDirection.x = 0;

        // Move "up" i.e. toward background
        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && jumpState == false)
        {
			if (feetColl.GetComponent<FeetCollision> ().canMove (vertMoveSpeed, Vector2.up)) {
				moveDirection.y = vertMoveSpeed;
				if (jumpState == true)
					landingPos += vertMoveSpeed;
				anim.SetInteger ("State", 1);
				canMoveY = true;
			} else
				canMoveY = false;
        }

        // Move "down" i.e. toward foreground
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) && jumpState == false)
        {
			if (feetColl.GetComponent<FeetCollision> ().canMove (-vertMoveSpeed, Vector2.down)) {
				moveDirection.y = -vertMoveSpeed;
				if (jumpState == true)
					landingPos += -vertMoveSpeed;
				anim.SetInteger ("State", 1);
				canMoveY = true;
			} else
				canMoveY = false;
        }

        // No vertical movement
		if ((!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.DownArrow) && jumpState == false) || canMoveY == false)
            moveDirection.y = 0;

		//attack animation
		if (Input.GetKey (KeyCode.Y)) {
			attacking = true;
			anim.SetInteger ("State", attackState);

		}

        // Idle animation
		if (moveDirection.x == 0.0f && moveDirection.y == 0.0f && attacking == false)
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
			canMoveY = true;
                landingPos = vertPos; // Holds value of ground position if jumping
                moveDirection.y = jumpSpeed;
                jumpState = true;

        }
		if (jumpState == true)
        {
            moveDirection.y -= gravity * Time.deltaTime;
            gravity += 0.5f;

			//This detects if there is a platform under the character or not when jumping
			// and depending on that, puts the foot collider in the right place for landing
			RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down, 10f);
			if (hit.collider != null) {
				if (hit.collider.tag == "Platform")
					feetColl.transform.position = new Vector3 (hit.collider.transform.position.x, hit.collider.transform.position.y + 0.3f, feetColl.transform.position.z);
				else if (hit.collider.name == "Top Ground Collider") {
					feetColl.transform.position = new Vector3 (hit.collider.transform.position.x, hit.collider.bounds.ClosestPoint(hit.point).y - 0.5f, feetColl.transform.position.z);
				}
			}
			if(transform.position.y < feetColl.transform.position.y){
				moveDirection.y = 0;
				jumpState = false;
				gravity = 12.0f;
				transform.position = new Vector3 (transform.position.x,feetColl.transform.position.y, transform.position.z);
				feetColl.transform.position = new Vector3 (transform.position.x, feetColl.transform.position.y, feetColl.transform.position.z);

			}
        }

        // Apply all movements based on collective key input
        controller.Move(moveDirection * Time.deltaTime);
		attacking = false;
    }


	/*
    // Handles fall of jump
    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Feet Collider")
        {
            if (moveDirection.y < 0)
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
	*/
		
}
