using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour {

	public float speed; 
	public Text countText;
	public Text winText;
	private Rigidbody rb;
	private int count;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	  
	void FixedUpdate ()
	{
		float moveHorizantal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizantal, -1.0f, moveVertical); // This code moves the ball in the three dimensions
			
		rb.AddForce (movement * speed); // With thid code, we can change the speed outside the script
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText();
			// This code deactivates the "easy" or yellow pick up objects(cubes that give you points) when the ball collides with them. It also adds 1 point to the counter.
		}
		if (other.gameObject.CompareTag ("Pick Up1")) 
		{
			other.gameObject.SetActive (false);
			count = count + 2;
			SetCountText();
			// This code deactivates the "hard" or red pick up objects(cubes that give you points) when the ball collides with them. It also adds 2 points to the counter. 

		} 
	}
	void SetCountText ()
	{
		countText.text = "Count:" + count.ToString ();
		if (count >= 16)
			winText.text = "You Win!";
		// When the player collects all the cubes, this code displays the text that says that the player won. 
	}
}