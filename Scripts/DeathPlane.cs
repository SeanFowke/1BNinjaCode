using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlane : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name.Equals("DeathSound"))
		{
			col.SendMessage("playDeathSound");
		}
		if (col.gameObject.tag.Equals("Player"))
		{
			col.SendMessage("reloadLevel");
		}
		
	}
}
