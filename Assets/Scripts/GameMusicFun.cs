using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusicFun : MonoBehaviour {

	public AudioClip megabong, titanic;
	public AudioSource player;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetString("sans") == "bad time")
			player.clip = megabong;
		else
			player.clip = titanic;

		player.Play();
	}
}
