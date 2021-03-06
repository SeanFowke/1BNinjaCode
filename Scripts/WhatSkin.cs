using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhatSkin : MonoBehaviour {

	//Skin tracker
	private int Skin = 1;



	// Use this for initialization
	void Start () {
		// Don't destroy this object because this object tells us which skin to use.
		DontDestroyOnLoad(this.gameObject);
	}



	// Update is called once per frame
	void Update () {
		
	}

	public void setSkin(int i)
	{
		//Change the skin
		Skin = i;
		Debug.Log("Skin equals " + Skin);
	}

	public int getSkin()
	{
		//This is called by the playercontroller to know which skin to draw.
		//This is saved in ChosenSkin and accordingly, the skin is chosen.
		return Skin;
	}
}
