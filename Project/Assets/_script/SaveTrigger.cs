using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTrigger : TriggerObject 
{
	protected override void OnTriggerPlayer (Player player)
	{
		var sceneName = SceneManager.GetActiveScene().name;
		var savepoint = new SavePoint (sceneName,transform.position);
		SavePointMgr.Instance.SaveSavePoint (savepoint);
	}
}
