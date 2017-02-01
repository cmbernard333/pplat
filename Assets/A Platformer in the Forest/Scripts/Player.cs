using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float maxSpeed = 10f;
	bool facingRight = true;

	private Animator anim;

	// Use this for initialization
	void Start () 
	{
		this.anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		// retrieve the horizontal acceds for moving from the Input (stick, joypad, etc)
		float moveAccess = Input.GetAxis("Horizontal");

		this.anim.SetFloat("Speed",Mathf.Abs(moveAccess));

		// add a Vector2 force to rigid body by multipying the access by the max speed
		GetComponent<Rigidbody2D>().AddForce(Vector2.right * (moveAccess * this.maxSpeed));

		// If the input is moving the player right and the player is facing left...
        if(moveAccess > 0 && !this.facingRight)
		{
            // ... flip the player.
            Flip();
		}
        // Otherwise if the input is moving the player left and the player is facing right...
        else if(moveAccess < 0 && this.facingRight)
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
