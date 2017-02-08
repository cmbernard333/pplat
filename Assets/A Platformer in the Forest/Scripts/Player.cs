using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () 
	{
		this.anim = GetComponent<Animator>();
		this.rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Jump();
		Move();
	}

	void Jump()
	{
		float moveVertical = Input.GetAxis("Vertical");

		if (moveVertical > 0)
			this.rb2d.AddForce(transform.up * maxSpeed);
	}

	void Move() 
	{
		// retrieve the horizontal acceds for moving from the Input (stick, joypad, etc)
		float moveHorizontal = Input.GetAxis("Horizontal");

		this.anim.SetFloat("Speed",Mathf.Abs(moveHorizontal));

		// add a Vector2 force to rigid body by multipying the access by the max speed
		this.rb2d.AddForce(Vector2.right * (moveHorizontal * this.maxSpeed));

		// If the input is moving the player right and the player is facing left...
        if(moveHorizontal > 0 && !this.facingRight)
		{
            // ... flip the player.
            Flip();
		}
        // Otherwise if the input is moving the player left and the player is facing right...
        else if(moveHorizontal < 0 && this.facingRight)
		{
            // ... flip the player.
            Flip();
		}
	}

	// This function flips the direction of the object based on the movement
	void Flip()
	{
		Vector3 theScale = transform.localScale;
		// get the current facing right status 
		this.facingRight = !this.facingRight;
		// flip to the other direction
		theScale.x *= -1;
		// set the value
		transform.localScale = theScale;
	}
}
