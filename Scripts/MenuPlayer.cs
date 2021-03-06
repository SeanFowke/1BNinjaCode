using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuPlayer : MonoBehaviour {

	//Initialize all the texts
	private Vector2 MenuPlayerTransform;
	private float TimeToInvokeMenu;
	public Text StartGameTimer;
	public Text HowToPlayTimer;
    public Text CreditsTimer;
    public Text SkinTimer;
	public Text QuitTimer;
	public Text StartGame;
	public Text HowToPlay;
    public Text Credits;
    public Text Skins;
	public Text Quit;

	//Skin objects chekc SkinsMenu for more info
	private GameObject FindSkin;
	private WhatSkin Skin;
	private int ChosenSkin;

	private SpriteRenderer spriteR;
	private Sprite[] sprites;
	private string spriteNames = "Skins";

	int position;
	// Use this for initialization
	void Start () {

		Cursor.visible = false;

		if (FindSkin = GameObject.Find("WhatSkin"))
		{
			Skin = FindSkin.GetComponent<WhatSkin>();
			ChosenSkin = Skin.getSkin();
		}

		Time.timeScale = 1.0f;
		TimeToInvokeMenu = Time.time;
		MenuPlayerTransform = new Vector2(this.transform.position.x, this.transform.position.y);
		//Keep track of where the player is
		position = 0;

		
		spriteR = this.gameObject.GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>(spriteNames);
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(Time.time - TimeToInvokeMenu);

		if (Input.GetMouseButtonDown(0))
		{
			//Keep position within the limits of the screen
			if (position == 5)
			{
				position = 0;
			}
			// Player pressed the mouse button --> Increase the position.
			position++;

			switch (position)
			{
				case 1:
					//Zero out all the other timers
					HowToPlayTimer.text = "";
					SkinTimer.text = "";
                    CreditsTimer.text = "";
					QuitTimer.text = "";
					//Change the position of the player according to the position
					MenuPlayerTransform = new Vector2(80, 388);
					this.transform.position = MenuPlayerTransform;
					// Change the colors of the texts
					StartGame.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					Skins.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);		
					Credits.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);
					Quit.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//Grey
					//Get the time
					TimeToInvokeMenu = Time.time;
					break;
				case 2:
					HowToPlay.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					StartGame.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);
                    Credits.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);//Red
					Quit.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//Grey
					StartGameTimer.text = "";
					SkinTimer.text = "";
                    CreditsTimer.text = "";
					QuitTimer.text = "";
					MenuPlayerTransform = new Vector2(410, 388);
					this.transform.position = MenuPlayerTransform;
					TimeToInvokeMenu = Time.time;
					break;
                case 3:
                    HowToPlayTimer.text = "";
                    SkinTimer.text = "";
                    StartGameTimer.text = "";
					QuitTimer.text = "";
					MenuPlayerTransform = new Vector2(700, 388);
                    this.transform.position = MenuPlayerTransform;
                    StartGame.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);
                    Credits.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
                    Skins.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);
                    HowToPlay.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);
					Quit.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//Grey
					TimeToInvokeMenu = Time.time;
                    break;
                case 4:
					Skins.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					HowToPlay.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//Grey
                    Credits.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);
					Quit.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//Grey
					StartGameTimer.text = "";
					HowToPlayTimer.text = "";
                    CreditsTimer.text = "";
					QuitTimer.text = "";
                    MenuPlayerTransform = new Vector2(900, 388);
					this.transform.position = MenuPlayerTransform;
					TimeToInvokeMenu = Time.time;
					break;

				case 5:
					Quit.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
					HowToPlay.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//Grey
					Credits.color = new Color(0.7921569f, 0.145098f, 0.145098f, 1.0f);
					Skins.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);
					StartGameTimer.text = "";
					HowToPlayTimer.text = "";
					CreditsTimer.text = "";
					SkinTimer.text = "";
					MenuPlayerTransform = new Vector2(960, 31);
					this.transform.position = MenuPlayerTransform;
					TimeToInvokeMenu = Time.time;
					break;


			}
		}

		switch(position)
		{
			case 1:
				//Store the time
				StartGameTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >=3.0f)
				{
					//When the player spends more than three seconds over one option, change the scene accordingly
					SceneManager.LoadScene("Level 1");
					
				}
				break;
			case 2:
				HowToPlayTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >=3.0f)
				{
					SceneManager.LoadScene("How to play");
				}
				break;
            case 3:
                CreditsTimer.text = (Time.time - TimeToInvokeMenu).ToString();
                if (Time.time - TimeToInvokeMenu >= 3.0f)
                {
                    SceneManager.LoadScene("Credits");
                }
                break;
            case 4:
				SkinTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >= 3.0f)
				{
					SceneManager.LoadScene("Skins");
				}
				break;
			case 5:
				QuitTimer.text = (Time.time - TimeToInvokeMenu).ToString();
				if (Time.time - TimeToInvokeMenu >= 3.0f)
				{
					Application.Quit();
				}
				break;
		}

		switch (ChosenSkin)
		{
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
