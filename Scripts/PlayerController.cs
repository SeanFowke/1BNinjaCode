using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
	// boolean that controls our world state. True = light False = Dark
	public static bool isLight;
    // determines weather or not the player is facing right
	public static bool isRight;
    // an int that determines our direction
    private int direction;
    // how fast can the player move
    public float speed;
    // used for slipping the sprite
	private Vector3 playerScale;
    //
	private LightDark camera;
    public GameObject player;
    // sends out our x variabel to be used by the audio object
    public static float x;
    //same thing with y
    public static float y;
    //control the audio
    public AudioSource AudioSource;
    public AudioClip swapWorld;
    SpriteRenderer playerSprite;
    //our rigidbody
    private Rigidbody2D rb;

	private GameObject FindSkin;
	private WhatSkin Skin;
	private int ChosenSkin;

	private Sprite[] sprites;
	private string spriteNames = "Skins";

	// Use this for initialization
	void Start ()
    {
		Cursor.visible = false;
        playerScale = transform.localScale;
        // sets our default values for isLight and isRight;
		isLight = true;
		isRight = true;
        // get our rigid body component
        rb = GetComponent<Rigidbody2D>();
		//Find the camera
		camera = FindObjectOfType<LightDark>();
        // get our audio source
        AudioSource = GetComponent<AudioSource>();

        direction = 1;
        //get our sprite renderer
        playerSprite = gameObject.GetComponent<SpriteRenderer>();


		if (FindSkin = GameObject.Find("WhatSkin"))
		{
			Skin = FindSkin.GetComponent<WhatSkin>();
			ChosenSkin = Skin.getSkin();
		}
		sprites = Resources.LoadAll<Sprite>(spriteNames);

		switch (ChosenSkin)
		{
			case 1:
				playerSprite.sprite = sprites[2];
				break;
			case 2:
				playerSprite.sprite = sprites[1];
				break;
			case 3:
				playerSprite.sprite = sprites[0];
				break;

		}


	}
	
	// Update is called once per frame
	void Update ()
    {
        // first it will switch the world to whatever state we need it to be in 
        switchWorld();
        // then checks if is right is true or false and sets our direction to be equal to that
        if (isRight == true)
        {
            
            direction = 1;
            playerSprite.flipX = false;
            /*playerScale.x *= 1;
			transform.localScale = playerScale; */


        }
        else /*(isRight == false) */
        {

            direction = -1;
            playerSprite.flipX = true;
            /* playerScale.x *= -1;
             transform.localScale = playerScale;*/


        }

        // next move the player
        movePlayer();
        x = this.transform.position.x;
        y = this.transform.position.y;


        


    }

    // void method that will check to see if we are pressing the button down and switches the world state accordingly 
    void switchWorld()
    {
        if (Input.GetMouseButtonDown(0)&& isLight==true)
        {
            AudioSource.PlayOneShot(swapWorld);
            isLight = false;
            //Debug.Log("False");
			//Change camera background
			camera.changeBackground();
        }
        else if (Input.GetMouseButtonDown(0) && isLight == false)
        {
            AudioSource.PlayOneShot(swapWorld);
            isLight = true;
            //Debug.Log("True");
			camera.changeBackground();
		}
    }
    // move player moves the player according to our direction and multiplies it by our speed variable to give us our motion
    void movePlayer()
    {
       
            rb.velocity = new Vector2(direction * speed, rb.velocity.y); 
        
    }

	void flipPlayerLeft()
	{
        //Flip the player to the left by changing the isRight variable
        
		isRight = false;
	}
	void flipPlayerRight()
	{
		
		isRight = true;
        
    }

    //reload the level and set the changing booleans to default;
    void reloadLevel()
    {
        
        
        isLight = true;
        isRight = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

	//If you collide with a boulder, then constraint the Y axis. If you don't do this, the player would rise up with the boulder.
	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag.Equals("Boulder With Two"))
		{
			rb.constraints = RigidbodyConstraints2D.FreezePositionY;
		}
		else if (col.gameObject.tag.Equals("Boulder"))
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}

	}

	private void OnCollisionExit2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Boulder With Two"))
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}
		else if (col.gameObject.tag.Equals("Boulder"))
		{
			rb.constraints = RigidbodyConstraints2D.None;
		}

	} 


    

}
