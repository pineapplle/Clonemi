using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveTrigger : TriggerObject 
{
	public int LevelNum;
	private SavePoint _savePoint;

	private void Awake()
	{
		_savePoint = new SavePoint (SceneManager.GetActiveScene().name,transform.position);
	}

	protected override void OnTriggerPlayer (Player player)
	{
		SavePointMgr.Instance.SaveSavePoint (_savePoint);
	}
}
