using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour {

    int[] playerScores = { 0, 0, 0 };
    Vector3[] playerStartPos = {new Vector3(0, 0.51f,3.65f), new Vector3(4.2f, 0.51f, -2.8f), new Vector3(-4.2f, 0.51f, -2.8f) };
    GameController gController;
    InputManager iManager;
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2;
    [SerializeField] GameObject p3;
    public ScoreTextScript sts;
    // Use this for initialization
    void Awake () {
        gController = GetComponent<GameController>();
        iManager = GetComponent<InputManager>();
        gController.SetupSpells();
        Respawn();
        sts.ScoreText(playerScores[0], playerScores[1], playerScores[2]);
	}
	

    public void OnWin(int winnerInt)
    {

        playerScores[winnerInt]++;
        sts.ScoreText(playerScores[0], playerScores[1], playerScores[2]);
        if (playerScores[winnerInt] >= 5f)
        {
            PlayerWin(winnerInt);
        }
        else
        {
            ResetGame();
        }
    }

    void PlayerWin(int winner)
    {
        print("Winner is player "+ winner+1);
        //reset scores
        playerScores[0] = playerScores[1] = playerScores[2] = 0;
        //new game
        ResetGame();
    }

    public void Respawn()
    {
        GameObject t1 = Instantiate(p1, playerStartPos[0], Quaternion.identity);
        iManager.pc1 = t1.GetComponent<PlayerController>();
        GameObject t2 = Instantiate(p2, playerStartPos[1], Quaternion.identity);
        iManager.pc2 = t2.GetComponent<PlayerController>();
        GameObject t3 = Instantiate(p3, playerStartPos[2], Quaternion.identity);
        iManager.pc3 = t3.GetComponent<PlayerController>();
        gController.GetPlayers();
        gController.AddSpells(iManager.pc1);
        gController.AddSpells(iManager.pc2);
        gController.AddSpells(iManager.pc3);
    }

    void ResetGame()
    {
        //display score

        //delete winner
        Destroy(GameObject.FindGameObjectWithTag("Wizard").gameObject);
        //instantiate & place players
        Respawn();
    }

}
