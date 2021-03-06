using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rb;


    public int speed;
    
	// Use this for initialization
	void Start () {
        rb = this.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        updateColour();


    }


	private void OnTriggerEnter2D(Collider2D col)
	{
		
		Debug.Log(col.gameObject.tag);
		if (col.gameObject.tag.Equals("DarkSwap"))//&& PlayerController.isLight == true)
		{

			Destroy(gameObject);
		}
		else if (col.gameObject.tag.Equals("LightSwap")) //&& PlayerController.isLight == false)
		{
			Debug.Log("Ive collided");
			Destroy(gameObject);
		}
	}

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag.Equals("PlatformDark") || col.gameObject.tag.Equals("PlatformLight") || col.gameObject.tag.Equals("Boulder"))
		{
			Destroy(gameObject);
			
		}
	}

	void updateColour()
    {
        SpriteRenderer bullet = gameObject.GetComponent<SpriteRenderer>();
        if (PlayerController.isLight == true)
        {
            bullet.color = new Color(1f, 1f, 1f, 1f);
        }
        else
        {
            bullet.color = new Color(0.5f, 0.5f, 0.5f, 0.4f);
        }
    }
    
}
