using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Dice dice;
    public WinPanel winPanel;

    int activePlayer;
    int diceNumber;

    

    [System.Serializable]
    public class Player
    {
        public string playerName;
        public Stone stone;

        public GameObject rollDiceButton;
        public enum PlayerTypes
        {
            CPU,
            HUMAN
        }
        public PlayerTypes playerTypes;
          
    }
    public List<Player> playerList = new List<Player>();

    public enum States
    {
        WAITTING,
        ROLL_DICE,
        SWTCH_PLAYER

    }
    public States state;
     void Awake()
    {
        instance = this;

        for (int i = 0; i < playerList.Count; i++)
        {
            if(SaveSettings.players[i] =="HUMAN")
            {
                playerList[i].playerTypes = Player.PlayerTypes.HUMAN;
            }
            else if (SaveSettings.players[i] == "CPU")
            {
                playerList[i].playerTypes = Player.PlayerTypes.CPU;
            }
        }
    }
     void Start()
    {
        //ActivateButton(false);
        DeativateAllButton();
        winPanel.gameObject.SetActive(false);

        //activePlayer = Random.Range(0,playerList.Count);
        InfoBox.instance.ShowMessage(playerList[activePlayer].playerName + " start first!");
    }
    void Update()
    {
        if(playerList[activePlayer].playerTypes == Player.PlayerTypes.CPU )
        {
            switch(state)
            {
                case States.WAITTING:
                    {

                    }
                    break;
                case States.ROLL_DICE:
                    {
                        StartCoroutine(RollDiceDelay());
                        state = States.WAITTING;
                    }
                    break;
                case States.SWTCH_PLAYER:
                    {
                        activePlayer++;
                        activePlayer %= playerList.Count;

                        state = States.ROLL_DICE;
                    }
                    break;
            }
        }

       if(playerList[activePlayer].playerTypes == Player.PlayerTypes.HUMAN)
        {
            switch (state)
            {
                case States.WAITTING:
                    {

                    }
                    break;
                case States.ROLL_DICE:
                    {
                        // ActivateButton(true);
                        ActivateSpesficButton(true);
                        state = States.WAITTING;
                    }
                    break;
                case States.SWTCH_PLAYER:
                    {
                        activePlayer++;
                        activePlayer %= playerList.Count;
                        //INFO BOX
                        InfoBox.instance.ShowMessage(playerList[activePlayer].playerName + "'s Turn!");

                        state = States.ROLL_DICE;
                    }
                    break;
            }
        }
    }

    IEnumerator RollDiceDelay()
    {
        yield return new WaitForSeconds(2);
      //  diceNumber = Random.Range(1, 7);
        // ROLL THE PHISICAL DICE
        dice.RollDice();
    }
    public void RollNumber(int _dicenumber)// CALL FROM THE DICE
    {
        diceNumber = _dicenumber;
        //INFO BOX
        InfoBox.instance.ShowMessage(playerList[activePlayer].playerName + " has roll a " + diceNumber);
        //make a turn
        playerList[activePlayer].stone.MakeTurn(diceNumber);

        
    }

    //void ActivateButton(bool on)
    //{
    //    rollDiceButton.SetActive(on);
    //}

    public void HumanRollDice()
    {
        //  ActivateButton(false);
        ActivateSpesficButton(false);
        StartCoroutine(RollDiceDelay());
    }
    void ActivateSpesficButton(bool on)
    {
        playerList[activePlayer].rollDiceButton.SetActive(on);
    }
    void DeativateAllButton()
    {
        for(int i=0; i<playerList.Count;i++)
        {
            playerList[i].rollDiceButton.SetActive(false);
        }
    }
    public void ReportWinner()
    {
        //SHOW PLAYER STUFF
        winPanel.gameObject.SetActive(true);
        winPanel.ShowWinMessage(playerList[activePlayer].playerName);
       // Debug.Log(playerList[activePlayer].playerName +" has win this round!");
    }
}

