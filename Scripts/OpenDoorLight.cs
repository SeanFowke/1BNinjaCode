using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorLight : MonoBehaviour {

	private int triggerCounter;
	private Collider2D LightCol;

	private void Start()
	{
		triggerCounter = 1;
		LightCol = GetComponent<Collider2D>();
	}

	private void Update()
	{
		switchSelf();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (triggerCounter > 0)
		{
			if (col.gameObject.tag.Equals("DarkBullet"))
			{

				SendMessageUpwards("OpenUp");
				triggerCounter--;
			}
		}
		Destroy(col.gameObject);
	}

	void switchSelf()
	{
		//checks to see if the world is in a light state it ignores collisions with player. If the world is dark it collides with the player
		SpriteRenderer block = gameObject.GetComponent<SpriteRenderer>();
		if (PlayerController.isLight == true)
		{
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
			LightCol.enabled = true;
			block.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
		}
		else
		{
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
			LightCol.enabled = false;
			block.color = new Color(1.0f, 1.0f, 1.0f,1.0f);
		}
	}
}
