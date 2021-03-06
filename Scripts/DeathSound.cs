using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour {
    
    public AudioSource AudioSource;
    public AudioClip hurt;
    GameObject player;
	GameObject boulder;
	//GameObject BoulderWithTwoButtons;
    private float x;
    private float y;
    
    // Use this for initialization
    void Start ()
    {
        DontDestroyOnLoad(this.gameObject);
        AudioSource = GetComponent<AudioSource>();
	

	}
	
	// Update is called once per frame
	void Update ()
    {
		
		
		//BoulderWithTwoButtons = GameObject.Find("BoulderWithTwoButtons");
		if (player = GameObject.Find("Player"))
		{
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), true);
		}
		if (boulder = GameObject.Find("Boulder"))
		{
			Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), boulder.GetComponent<Collider2D>(), true);
		}
		//Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), BoulderWithTwoButtons.GetComponent<Collider2D>(), true);
		x = PlayerController.x;
        y = PlayerController.y;
        transform.position = new Vector2(x, y-0.2f);
        
    }
    //play the death sound
    void playDeathSound()
    {
        Debug.Log("should be playing sound");
        AudioSource.PlayOneShot(hurt,1f);
		

	}
}
