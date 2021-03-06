using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boulder : MonoBehaviour {

	Rigidbody2D BoulderRigidBody;
    GameObject platformlight;
    GameObject platformdark;
    // Use this for initialization
    void Start () {

		BoulderRigidBody = GetComponent<Rigidbody2D>();
        platformlight = GameObject.FindWithTag("PlatformLight");
        platformdark = GameObject.FindWithTag("PlatformDark");

    }

    // Update is called once per frame
    void Update ()
    {
        //switchsSelf();

    }

	private void StopRightThere()
	{
		//Zero out the velocity and the gravity of the boulder once it hits the stop boulder trigger
		BoulderRigidBody.gravityScale = 0.0f;
		BoulderRigidBody.velocity = new Vector2(0.0f, 0.0f);
        

    }

	private void OpenUp()
	{
		BoulderRigidBody.gravityScale = 0.0f;
		BoulderRigidBody.velocity = new Vector2(0.0f, 1.0f);
	}

    /*void switchsSelf()
    {
        if (PlayerController.isLight == true)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), platformlight.GetComponent<Collider2D>(), true);

        }
        else
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), platformlight.GetComponent<Collider2D>(), false);
        }

        if (PlayerController.isLight == false)
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), platformdark.GetComponent<Collider2D>(), true);

        }
        else
        {
            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), platformdark.GetComponent<Collider2D>(), false);
        }
    } */
}
