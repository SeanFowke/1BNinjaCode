using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDark : MonoBehaviour {

     

    //gives the player a game object
    GameObject player;
	Collider2D DarkSpikeCol;
    




    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
		DarkSpikeCol = GetComponent<Collider2D>();
        

    }

    // Update is called once per frame
    void Update()
    {
        switchSelf();

    }

    void switchSelf()
    {
        //checks to see if the world is in a light state it ignores collisions with player. If the world is dark it collides with the player
        SpriteRenderer block = gameObject.GetComponent<SpriteRenderer>();
        if (PlayerController.isLight == true)
        {
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
			DarkSpikeCol.enabled = true;

			block.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
			DarkSpikeCol.enabled = false;
			block.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
        }
    }
    //call on player to reload the level
    private void OnTriggerEnter2D(Collider2D col)
    {
		if (col.gameObject.name.Equals("DeathSound"))
		{
			col.SendMessage("playDeathSound");
			Debug.Log("Collided with deathsound");
		}
		if (col.gameObject.tag.Equals("Player"))
        {
			Debug.Log("Collided with player");
            col.SendMessage("reloadLevel");
        }

    }
}
