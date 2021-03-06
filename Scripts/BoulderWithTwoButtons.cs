using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderWithTwoButtons : MonoBehaviour {


	Rigidbody2D BoulderRigidBody;
	private int LightButtonPressed;
	private int DarkButtonPressed;
	GameObject platformlight;
	GameObject platformdark;
    
    
    
    // Use this for initialization
    void Start()
	{

		BoulderRigidBody = GetComponent<Rigidbody2D>();
		platformlight = GameObject.FindWithTag("PlatformLight");
		platformdark = GameObject.FindWithTag("PlatformDark");
       
        LightButtonPressed = 1;
		DarkButtonPressed = 1;

	}

	// Update is called once per frame
	void Update()
	{
		//switchsSelf();

	}

	private void StopRightThere()
	{
		//Zero out the velocity and the gravity of the boulder once it hits the stop boulder trigger
		BoulderRigidBody.gravityScale = 0.0f;
		BoulderRigidBody.velocity = new Vector2(0.0f, 0.0f);


	}

	// Methods used to keep track of which button were pressed.
	private void ShouldIOpenUpYetLight()

	{
		Debug.Log("Should I Light");
		if(LightButtonPressed > 0)
		{
            
            LightButtonPressed--;
			OpenUp();
		}
	}
	private void ShouldIOpenUpYetDark()
	{
		Debug.Log("Should I Dark");
		if (DarkButtonPressed > 0)
		{
            
            DarkButtonPressed--;
			OpenUp();
		}

	}
	private void OpenUp()
	{

		if (LightButtonPressed <= 0 && DarkButtonPressed <= 0)
		{
			Debug.Log("Abracadabra");
			BoulderRigidBody.gravityScale = 0.0f;
			BoulderRigidBody.velocity = new Vector2(0.0f, 1.0f);
		}
	}
}
