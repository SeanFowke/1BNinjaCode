using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HowToPlayPlayer : MonoBehaviour
{

    private Vector2 MenuPlayerTransform;
    private float TimeToInvokeMenu;
    public Text HowToPlayTimer;
    public Text HowToPlay;

	private GameObject FindSkin;
	private WhatSkin Skin;
	private int ChosenSkin;

	private SpriteRenderer spriteR;
	private Sprite[] sprites;
	private string spriteNames = "Skins";


	int position;
    // Use this for initialization
    void Start()
    {
		Cursor.visible = false;
		if (FindSkin = GameObject.Find("WhatSkin"))
		{
			Skin = FindSkin.GetComponent<WhatSkin>();
			ChosenSkin = Skin.getSkin();
		}
		
		spriteR = this.gameObject.GetComponent<SpriteRenderer>();
		sprites = Resources.LoadAll<Sprite>(spriteNames);


		Time.timeScale = 1.0f;
        TimeToInvokeMenu = Time.time;
        MenuPlayerTransform = new Vector2(this.transform.position.x, this.transform.position.y);
        position = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time - TimeToInvokeMenu);
        if (Input.GetMouseButton(0))
        {
            Debug.Log("Hey there");
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (position == 2)
            {
                position = 0;
            }
            position++;

            switch (position)
            {
                case 1:
                    
                    
                    MenuPlayerTransform = new Vector2(730, MenuPlayerTransform.y);
                    this.transform.position = MenuPlayerTransform;
                    HowToPlay.color = new Color(0.172549f, 0.3843138f, 0.9058824f, 1.0f);//Blue
                    TimeToInvokeMenu = Time.time;
                    break;
                case 2:
                    HowToPlayTimer.text = "";
                    HowToPlay.color = new Color(0.1960784f, 0.1960784f, 0.1960784f, 1.0f);//grey

                    MenuPlayerTransform = new Vector2(-300, MenuPlayerTransform.y);
                    this.transform.position = MenuPlayerTransform;
                    TimeToInvokeMenu = Time.time;
                    break;
                

            }
        }

        switch (position)
        {
            case 1:
                HowToPlayTimer.text = (Time.time - TimeToInvokeMenu).ToString();
                if (Time.time - TimeToInvokeMenu >= 3.0f)
                {
                    SceneManager.LoadScene("MainMenu");

                }
                break;
            case 2:
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
