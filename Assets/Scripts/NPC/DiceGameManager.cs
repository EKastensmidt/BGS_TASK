using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class DiceGameManager : MonoBehaviour
{
    [SerializeField] private GameObject winText, looseText;
    [SerializeField] private TextMeshProUGUI betAmountText;

    [Header("OPONENTS VARIABLES")]
    [SerializeField] private TextMeshProUGUI opponentsFirstDie;
    [SerializeField] private TextMeshProUGUI opponentsSecondDie;
    [SerializeField] private TextMeshProUGUI opponentsTotal;

    [Header("PLAYER VARIABLES")]
    [SerializeField] private TextMeshProUGUI playerFirstDie;
    [SerializeField] private TextMeshProUGUI playerSecondDie;
    [SerializeField] private TextMeshProUGUI playerTotal;

    private int betAmount;

    private Player player;
    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void OnBetDone()
    {
        if(betAmount == 0)
        {
            return;
        }

        looseText.SetActive(false);
        winText.SetActive(false);

        int playerTotalScore = PlayerDice();
        int opponentsTotalScore = OpponentsDice();

        opponentsTotal.text = "TOTAL: " + opponentsTotalScore.ToString();
        playerTotal.text = "TOTAL: " + playerTotalScore.ToString();

        if (playerTotalScore == opponentsTotalScore)
        {
            OnBetDraw();
        }
        else if(playerTotalScore < opponentsTotalScore)
        {
            OnBetLoose();
        }
        else
        {
            OnBetWin();
        }
    }

    public void OnBetWin()
    {
        player.AddMoney(betAmount);
        winText.SetActive(true);
    }

    public void OnBetLoose()
    {
        player.LooseMoney(betAmount);
        looseText.SetActive(true);
    }

    public void OnBetDraw()
    {

    }

    private int PlayerDice()
    {
        int playerTotalScore = 0;
        int aux = RollDice();
        playerFirstDie.text = aux.ToString();
        playerTotalScore += aux;
        aux = RollDice();
        playerSecondDie.text = aux.ToString();
        playerTotalScore += aux;

        return playerTotalScore;
    }

    private int OpponentsDice()
    {
        int opponentsTotalScore = 0;
        int aux = RollDice();
        opponentsFirstDie.text = aux.ToString();
        opponentsTotalScore += aux;
        aux = RollDice();
        opponentsSecondDie.text = aux.ToString();
        opponentsTotalScore += aux;

        return opponentsTotalScore;
    }

    private int RollDice()
    {
        int value = Random.Range(1, 6);
        return value;
    }

    public void IncreaseBet()
    {
        betAmount += 5;
        if(betAmount >= 100)
        {
            betAmount = 100;
        }

        betAmountText.text = betAmount.ToString();
    }

    public void DecreaseBet()
    {
        betAmount -= 5;
        if(betAmount<= 0)
        {
            betAmount = 0;
        }
        betAmountText.text = betAmount.ToString();
    }
}
