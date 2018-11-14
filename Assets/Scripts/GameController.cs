using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    PlayerController[] players = new PlayerController[3];
    List<Spell> spellList = new List<Spell>();
    ScoreController boardController;
    int wizAlive = 3;
    // Use this for initialization
    void Start() {
        //get scorer
        boardController = GetComponent<ScoreController>();
        //get all your spells
        //initiate Wizards
        GetPlayers();
        //
        //give spells to wizards
        foreach (PlayerController player in players) {
            //add 5 random spells
            AddSpells(player);
            //send reference of self
            player.myDad = this;
            
        }

    }

    public void SetupSpells() {

        Spell[] toConvert = GetComponents<Spell>();
        //probably could just use an array here
        foreach (Spell sp in toConvert)
        {
            spellList.Add(sp);
        }
    }

    public void AddSpells(PlayerController player) {
        if (player == null) { print("player null"); }
        if (spellList.Count == 0) { print("nospells"); }
        for (int i = 0; i < 5; i++)
        {
            player.AddSpell(spellList[Random.Range(0, spellList.Count)]);
        }
    }

    public void GetPlayers()
    {
        //initiate Wizards
        GameObject[] tempConvert = GameObject.FindGameObjectsWithTag("Wizard");
        foreach (GameObject wiz in tempConvert)
        {
            players[wiz.GetComponent<PlayerController>().myID] = wiz.GetComponent<PlayerController>();
        }
        wizAlive = 3;
    }

    public Spell GetNewSpell() {

        return spellList[Random.Range(0, spellList.Count)];
    }

    public void WizardDeath()

    {
        wizAlive--;
        if (wizAlive == 1)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        //end the game!
        int winner = 9;
        foreach (PlayerController wiz in players)
        {
            if (wiz!=null)
            {
                winner = wiz.myID;
                continue;
            }

        }
        if (winner == 9) { return; }
        boardController.OnWin(winner);
    }

}
