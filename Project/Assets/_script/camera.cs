using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {


	void Start () {
		
	}
	

	void LateUpdate () {
		var pos = Player.Current.transform.position;
		transform.position = new Vector3 (pos.x, transform.position.y, transform.position.z);


	}
}
