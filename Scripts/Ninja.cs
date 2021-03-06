using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : MonoBehaviour {

	public AudioSource AudioSource;
	public AudioClip Kabuki;

	// Use this for initialization
	void Start () {

		AudioSource = GetComponent<AudioSource>();
		

	}


	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.gameObject.tag.Equals("Player"))
		{
			AudioSource.PlayOneShot(Kabuki);
		}
		
	}
}
