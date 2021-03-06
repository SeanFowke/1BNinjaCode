using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkinsMenu : MonoBehaviour {


	// The same thing as the main menu
	private Vector2 MenuPlayerTransform;
	private float TimeToInvokeMenu;

	public Text DefaultSkinTimer;
	public Text SuitSkinTimer;
	public Text MainMenuTimer;
	public Text BikerNinjaTimer;


	public Text OneBNinja;
	public Text NinjaInASuite;
	public Text BikerNinja;

	//Hello my future self, you're probably wondering what the hell all this is, lemme explain:
	//We created a DontDestroyOnLoad object in the skins menu called WhatSkin.
	//This object simply keeps trach of which skin was chosen by the player.
	//Then we find this object through FindSkin and get the components of WhatSkin and store them in
	//the WhatSkin variable Skin.
	//To change sprites, you need a SpriteRenderer, so we creat one, and create an array of sprites, then store
	//The correct sprite in the SpriteRenderer.sprite.
	//The reason we create this sprite array is because we basically load up all the sprites we wanna use from
	//the folder "Resources/Skins" so we need an array to store all of these sprites


	// FindSkin, Skin, ChosenSkin (The skin tracker)

	private GameObject FindSkin;
	private WhatSkin Skin;
	private int ChosenSkin;

	//SpriteRenderer, sprite array, and "Skins" is the path within the folder "Resources"
	private SpriteRenderer spriteR;
	private Sprite[] sprites;
	private string spriteNames = "Skins";


	int position;
	// Use this for initialization
	void Start()
	{
		Cursor.visible = false;
		//Find WhatSkin
	if(	FindSkin = GameObject.Find("WhatSkin"))
		{ 
		//Get the component and save it in Skin.
		Skin = FindSkin.GetComponent<WhatSkin>();
		}
		Time.timeScale = 1.0f;
		TimeToInvokeMenu = Time.time;
		MenuPlayerTransform = new Vector2(this.transform.position.x, this.transform.position.y);
		position = 0;

		//Initialize ChosenSkin, the SpriteRenderer get the array of the sprites.
		ChosenSkin = 0;
		spriteR = this.gameObject.GetComponent<SpriteRenderer>();
		//Resources.LoadAll<Sprites>(PathString) --> This line looks inside the folder Resources/PathString
		sprites = Resources.LoadAll<Sprite>(spriteNames); // --> So here we are looking through Resources/Skins
	}

	// Update is called once per frame
	void Update()
	{
		//Debug.Log(Time.time - TimeToInvokeMenu);

		if (Input.GetMouseButtonDown(0))
		{
			if (position == 4)
			{
				position = 0;
			}
			position++;

			switch (position)
			{
				case 1:
					SuitSkinTimer.text = "";
					MainMenuTimer.text = "";
					BikerNinjaTimer.text = "";
					MenuPlayerTransform = new Vector2(80, MenuPlayerTransform.y);
					this.transform.position = MenuPlayerTransform;
					OneBNinja.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					NinjaInASuite.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f); 


					TimeToInvokeMenu = Time.time;
					break;
				case 2:
					DefaultSkinTimer.text = "";
					MainMenuTimer.text = "";
					BikerNinjaTimer.text = "";
					MenuPlayerTransform = new Vector2(349, MenuPlayerTransform.y);
					this.transform.position = MenuPlayerTransform;
					NinjaInASuite.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					OneBNinja.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);//Red

					TimeToInvokeMenu = Time.time;
					break;
				case 3:
					SuitSkinTimer.text = "";
					DefaultSkinTimer.text = "";
					MainMenuTimer.text = "";
					NinjaInASuite.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);
					BikerNinja.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					MenuPlayerTransform = new Vector2(700, MenuPlayerTransform.y);
					this.transform.position = MenuPlayerTransform;
					TimeToInvokeMenu = Time.time;
					break;
				case 4:
					DefaultSkinTimer.text = "";
					SuitSkinTimer.text = "";
					BikerNinjaTimer.text = "";
					NinjaInASuite.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);
					BikerNinja.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);
					MenuPlayerTransform = new Vector2(900, MenuPlayerTransform.y);
					this.transform.position = MenuPlayerTransform;
					TimeToInvokeMenu = Time.time;
					break;

			}
		}

		switch (position)
		{
			case 1:
				DefaultSkinTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >= 3.0f)
				{
					//Set which skin is chosen. This stored in the WhatSkin object which will not be destroyed.

					Skin.setSkin(1);

					//Here ChosenSkin is hardcoded but in other scripts we use Skin.getSkin()
					ChosenSkin = 1;

				}
				break;
			case 2:
				SuitSkinTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >= 3.0f)
				{
					Skin.setSkin(2);
					ChosenSkin = 2;
				}
				break;
			case 3:
				BikerNinjaTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >= 3.0f)
				{
					Skin.setSkin(3);
					ChosenSkin = 3;
				}
				break;
			case 4:
				MainMenuTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >= 3.0f)
				{
					SceneManager.LoadScene("MainMenu");
				}
				break;
		}

		switch(ChosenSkin)
		{
			//Draw the sprite
			case 1:
				spriteR.sprite = sprites[2];
				break;
			case 2:
				spriteR.sprite = sprites[1];
				break;
			case 3:
				spriteR.sprite = sprites[0];
				break;

		}
	}
}
