using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : TriggerObject {

	protected override void OnTriggerPlayer (Player player)
	{
		player.Die ();
	}
}
