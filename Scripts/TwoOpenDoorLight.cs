using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoOpenDoorLight : MonoBehaviour {

	private int triggerCounter; // counter for how many times the bullet actually collides with the button
	private Collider2D LightCol;
    public AudioSource AudioSource;
    public AudioClip lightbutton;
	private SpriteRenderer buttonSprite;
	private Sprite[] sprites;
	private string spriteNames = "Skins";


	private void Start()
	{
		triggerCounter = 1;
		LightCol = GetComponent<Collider2D>();
        AudioSource = GetComponent<AudioSource>();
		buttonSprite = GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>(spriteNames);
	}

	private void Update()
	{
		switchSelf();
	}

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (triggerCounter > 0)
		{
			if (col.gameObject.tag.Equals("LightBullet"))
			{
                AudioSource.PlayOneShot(lightbutton);
                //Debug.Log("Light Button collided with Light bullet");
                SendMessageUpwards("ShouldIOpenUpYetLight"); //Modify the lightbuttonpressed counter
				triggerCounter--;
				buttonSprite.sprite = sprites[3];
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
			LightCol.enabled = false;
			block.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
		}
		else
		{
			//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
			LightCol.enabled = true;
			block.color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
		}
	}
}
