using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SansSprite : MonoBehaviour {
	//public Sprite sans;
	public SpriteRenderer sansR;
	// Use this for initialization
	void Start () {
		sansR.enabled=false;
		if(PlayerPrefs.GetString("sans") == "bad time")
			sansR.enabled=true;
	}
}