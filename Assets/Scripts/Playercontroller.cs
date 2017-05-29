using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroller : MonoBehaviour {
	//the speed of the ball
	public float speed;
	//a YES/NO if we're on mobile or not
	public bool isMobile;
	//the current score the player has
	private int score;
	//the top score OR the number of children we've found
	private int topScore;
	//the parent objects of all the pickups
	public GameObject pickups;
	//the rigidbody of the player
	private Rigidbody rb;

	void Start ()
	{
		//if we've said this isMobile
		if (isMobile) {
			//set the screen to landscape
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			//set it to not full screen so we can use software-android buttons
			Screen.fullScreen = false;
		}
		//get the rigidbody from this game object
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate (){
		//create a float to hold the horizontal and verticle 
		float moveHorizontal;
		float moveVertical;

		//if it's for mobile then we should use touch input
		if (isMobile) {
			moveHorizontal = Input.GetAxis ("Mouse X");
			moveVertical = Input.GetAxis ("Mouse Y");
			if (Input.touchCount > 0) {
				//get the difference between this and the last frame
				moveHorizontal = Input.touches [0].deltaPosition.x;
				moveVertical = Input.touches [0].deltaPosition.y;
			}
		} else {
			//if we're not on mobile, just use the Arrow Keys
			moveHorizontal = Input.GetAxis ("Horizontal");
			moveVertical = Input.GetAxis ("Vertical");
		}
		//apply the movement we've gathered to this object
		Vector3 movement = new Vector3 (moveHorizontal,0.0f , moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		//if the object we've hit is a pickup
		if (other.gameObject.CompareTag("Pick Up")) {
			//turn it off!
			other.gameObject.SetActive (false);
		}
	}
}