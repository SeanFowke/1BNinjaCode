using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBox : MonoBehaviour {

    // switch for dark box 


    GameObject player;
	Collider2D DarkCol;

    // Use this for initialization
    void Start()
    {
		DarkCol = GetComponent<Collider2D>();
		
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        switchSelf();

		//Debug.Log(PlayerController.isLight);

    }

    void switchSelf()
    {
        //checks to see if the world is in a light state it ignores collisions with player. If the world is dark it collides with the player
        SpriteRenderer block = gameObject.GetComponent<SpriteRenderer>();
        if (PlayerController.isLight == true)
        {
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
			DarkCol.enabled = true;
			block.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
			DarkCol.enabled = false;
			block.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
        }
    }
}
