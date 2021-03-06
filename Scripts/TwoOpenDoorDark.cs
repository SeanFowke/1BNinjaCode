using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoOpenDoorDark : MonoBehaviour {

	private int triggerCounter;
	private Collider2D DarkCol;
    public AudioSource AudioSource;
    public AudioClip darkbutton;

	private SpriteRenderer buttonSprite;
	private Sprite[] sprites;
	private string spriteNames = "Skins";


	private void Start()
	{

		triggerCounter = 1;
		DarkCol = GetComponent<Collider2D>();
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
			if (col.gameObject.tag.Equals("DarkBullet"))
			{
                //Debug.Log("Dark Button collided with Dark bullet");
                AudioSource.PlayOneShot(darkbutton);
                SendMessageUpwards("ShouldIOpenUpYetDark");
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
