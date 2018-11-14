using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {


	public AudioSource sansSource;
	public bool pitchUp = false;
	public float pitchChange = 1.5f;

	 private void Start() {
		PlayerPrefs.SetString("sans","good time");
	}

	// Use this for initialization
	public void volumeSwitch () {

		SansScript sans = GameObject.Find("SansUndertale").GetComponent<SansScript>();

		if(!pitchUp)
		{
			sans.showSans();
			PlayerPrefs.SetString("sans","bad time");
			//sansSource.pitch = sansSource.pitch * pitchChange;
			pitchUp=true;
		}
		else
		{
			sans.hideSans();
			PlayerPrefs.SetString("sans","good time");
			//sansSource.pitch = sansSource.pitch / pitchChange;
			pitchUp=false;
		}
	}
}
