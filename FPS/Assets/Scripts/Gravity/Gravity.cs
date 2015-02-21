using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour {

	public bool canChangeGravity = true;
	public float timer = 0.0f;
	const float GRACE_PERIOD = 1.0f;
	public KeyCode flipGravityKey;
	public bool isGravityDown = true;
	public bool isGravityOverideOn = false;


	void Start () {
		// Sets the value of Gravity
		Physics.gravity = new Vector3(Physics.gravity.x, -3,Physics.gravity.z); 
		isGravityOverideOn = false;
	}
	

	void Update () {
		if(canChangeGravity == false && !GetGravityOveride()){
			GracePeriodTimer();
		}
		if(canChangeGravity && Input.GetKeyDown(flipGravityKey) && !GetGravityOveride()){
			ChangeGravity();
		}
		isGravityDown = GetDirectionOfGravity ();
	}

	// cahnges the sign of the y value of gravity
	public void ChangeGravity(){
		Physics.gravity = new Vector3(Physics.gravity.x, -Physics.gravity.y,Physics.gravity.z); 
		canChangeGravity = false;
	}

	//Starts the Timer for GracePeriod
	void GracePeriodTimer(){
		timer += Time.deltaTime;
		if (timer >= GRACE_PERIOD) {
			canChangeGravity = true;
			timer = 0.0f;
		}
	}

	// Gets Direction of Gravity .. True if down
	public bool GetDirectionOfGravity(){
		return (Physics.gravity.y < 0);
	}

	// Set to overide other gravity allowance .. true for no changing gravity
	public void SetGravityOveride(bool set){
		isGravityOverideOn = set;
	}

	// Get Overide Info
	public bool GetGravityOveride(){
		return isGravityOverideOn;
	}
}
