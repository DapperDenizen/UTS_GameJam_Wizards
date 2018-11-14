using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour {
	public Text text;

	public void ScoreText(int score1, int score2, int score3)
	{
		text.text = "Player 1: " + score1 + " | Player 2: " + score2 + " | Player 3: " + score3;
	}
}
