using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDark : MonoBehaviour {


	private bool colorLight;
	// Use this for initialization
	void Start () {
		colorLight = true;

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void changeBackground()
	{
		//Check for boolean and update the background
			if (colorLight)
			{
				Camera.main.backgroundColor = Color.black;
			}
			else
			{
				Camera.main.backgroundColor = Color.white;
			}
			colorLight = !colorLight;


	}
}
