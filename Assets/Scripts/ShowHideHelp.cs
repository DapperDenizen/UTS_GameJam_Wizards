using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideHelp : MonoBehaviour {

	public bool showingHelp=false;
	public MeshRenderer help;

	void toggleHelp () {
		if(showingHelp)
		{
			showingHelp=false;
			help.enabled=false;
		}
		else
		{
			showingHelp=true;
			help.enabled=true;
		}
	}
	
}
