using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwapLeft : MonoBehaviour {

	GameObject player;
	Collider2D LightSwapCol;


	// Use this for initialization
	void Start()
	{
		player = GameObject.Find("Player");
		LightSwapCol = GetComponent<Collider2D>();

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
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
			LightSwapCol.enabled = false;
			block.color = new Color(0.5f, 0.5f, 0.5f, 0.1f);
		}
		else
		{
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
			LightSwapCol.enabled = true;
			block.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag.Equals("Player"))
		{
			col.SendMessage("flipPlayerLeft");
		}
	}
}
