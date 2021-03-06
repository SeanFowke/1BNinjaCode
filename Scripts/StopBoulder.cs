using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBoulder : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col)
	{
		//Tell the boulder to stop if it hits this collider

		if(col.gameObject.tag.Equals("Boulder With Two") || col.gameObject.tag.Equals("Boulder"))
		{
			col.SendMessage("StopRightThere");
		}
		
	}
}
