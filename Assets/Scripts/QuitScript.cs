using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitScript : MonoBehaviour {

	public void Quit(){
		Application.Quit();
	}

	private void Start() {
		//Screen.SetResolution(1600,900,FullScreenMode.Windowed,60);
	}
}
