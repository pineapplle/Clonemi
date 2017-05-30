using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMgr : MonoBehaviour {

	public static LevelMgr Instance;
    public Level CurrentLevel;
	private const float ReloadTime = 3;

	private float _timer;
	private bool _reload;

	void Awake () 
	{
		Instance = this;
	}

	void Update () {
		if (_reload) 
		{
			if (_timer > ReloadTime) 
			{
				SavePointMgr.Instance.LoadSavePoint ();
				_timer = 0;
				_reload = false;
			}
			_timer += Time.deltaTime;
		}
	}

	public void LevelReload()
	{
		_reload = true;
	}
}

