using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerObject : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		var player = other.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			OnTriggerPlayer (player);
		}
	}

	void OnCollisionEnter2D(Collision2D other) 
	{
		var player = other.gameObject.GetComponent<Player> ();
		if (player != null) 
		{
			OnTriggerPlayer (player);
		}
	}

	protected virtual void OnTriggerPlayer(Player player)
	{
		
	}
}
