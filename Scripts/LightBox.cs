using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBox : MonoBehaviour {
	// switch for light box 

	//gives the player a game object
	Collider2D LightCol;
	GameObject player;


    

    
    // Use this for initialization
    void Start ()
    {
		LightCol = GetComponent<Collider2D>();
        player = GameObject.Find("Player");

    }
	
	// Update is called once per frame
	void Update ()
    {
        switchSelf();

    }

    void switchSelf()
    {
        //checks to see if the world is in a light state it ignores collisions with player. If the world is dark it collides with the player
        SpriteRenderer block = gameObject.GetComponent<SpriteRenderer>();
        if (PlayerController.isLight == true)
        {
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
			LightCol.enabled = false;
            block.color = new Color(0.5f, 0.5f, 0.5f, 0.1f);
        }
        else
        {
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
			LightCol.enabled = true;
			block.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
