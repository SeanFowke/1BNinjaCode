using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {


    public string level;
    public AudioSource AudioSource;
    public AudioClip gong;

	private int WhichScene = 1; //Keeps track of which scene we are on.
	private void Start()
	{
		AudioSource = GetComponent<AudioSource>();

		DontDestroyOnLoad(this.gameObject);

	}

	private void Update()
	{
		switch (WhichScene)
		{
			case 1: //If we're on scene 1, go to scene2
				level = "Level 2";
				break;
			case 2: // If we're on scene 2 go to scene3
				level = "Level 3";
				break;
			case 3:
				level = "Level 4";
				break;
			case 4:
				level = "Level 5";
				break;
			case 5:
				level = "Credits";
                WhichScene = 0;
				break;

		}
	}
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
            //Play the audio, change the scene, and increment WhichScene
            AudioSource.PlayOneShot(gong);
            Destroy(col.gameObject);
			SceneManager.LoadScene(level);
			WhichScene++;		


		}
	}

    

}
