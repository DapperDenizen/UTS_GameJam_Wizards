using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour {

	// Update is called once per frame
	public void PlayGame () {
		SceneManager.LoadSceneAsync("gameScene");
	}
}
