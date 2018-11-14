using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.PostProcessing;

public class SansScript : MonoBehaviour {

	public VideoPlayer videoPlayer;
	public MeshRenderer sansRender;
	public AudioSource megaloSource;
	public SpriteRenderer badTimeRender, helpRender;
	public Sprite normalHelp,sansHelp;

	public void showHelp() {
		helpRender.enabled=true;
	}

	public void toggleHelp() {
		if(helpRender.enabled) hideHelp();
		else showHelp();
	}

	public void hideHelp() {
		helpRender.enabled=false;
	}

	ColorGradingModel cgm;
	public void Start() {
				PlayerPrefs.SetString("sans","good time");

		PostProcessingProfile aaah = Camera.main.GetComponent<PostProcessingBehaviour>().profile;
		if(aaah!=null)
		{
			cgm = aaah.colorGrading;
			cgm.enabled = false;
		}
	}

	// Use this for initialization
	public void showSans () {
		
		if(cgm!=null)cgm.enabled=true;

		megaloSource.volume = 0;
		sansRender.enabled = true;
		badTimeRender.enabled=true;
		videoPlayer.Play();
		videoPlayer.loopPointReached += restoreVolume;
		helpRender.sprite = sansHelp;

		videoPlayer.SetDirectAudioVolume(0,1.0f);
	}

	public void restoreVolume(UnityEngine.Video.VideoPlayer vp) {
		megaloSource.volume=1;
		vp.SetDirectAudioVolume(0,0.0f);
	}

	public void hideSans() {

		if(cgm!=null)cgm.enabled=false;

		helpRender.sprite = normalHelp;
		sansRender.enabled = false;
		badTimeRender.enabled=false;
		videoPlayer.Stop();
		videoPlayer.SetDirectAudioVolume(0,0.0f);
		megaloSource.volume=1;
	}
}
