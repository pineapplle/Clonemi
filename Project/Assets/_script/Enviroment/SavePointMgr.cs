using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointMgr
{
	public static SavePointMgr Instance
	{
		get
		{ 
			if (_instance == null) 
			{
				_instance = new SavePointMgr ();
			}
			return _instance;
		}
	}
	private static SavePointMgr _instance;
	private SavePoint _last;

	public void SaveSavePoint(SavePoint savePoint)
	{
		_last = savePoint;
	}

	public void LoadSavePoint()
	{
		if (_last == null) {
			return;
		}
		Player.Current.Reborn ();
		Player.Current.transform.position = _last.SavePosition;
	}
}

public class SavePoint
{
	public string SceneName;
	public Vector2 SavePosition;

	public SavePoint(string name,Vector2 pos)
	{
		SceneName = name;
		SavePosition = pos;
	}
}