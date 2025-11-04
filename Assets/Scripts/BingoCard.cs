using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using TMPro;

public class BingoCard : MonoBehaviour
{
    public Space[] spaces = new Space[25];
    public Evaluator eval = new Evaluator();
    public BallCage cage = new BallCage();
    public System.Random r = new System.Random();
    public TextMeshProUGUI ballText = new TextMeshProUGUI();
    public TextMeshPro winText = new TextMeshPro();
    public List<BingoBall> bingoBalls = new List<BingoBall>();
    public int currentWinnings = 0;

    public void Play(int ballCount)
    {
        DaubCard(ballCount);
        //List<Evaluator.BingoPattern> wonPatterns = eval.Evaluate(this);
        DisplayWins(eval.Evaluate(this));
    }
    public void ResetCard()
    {
        for(int i = 0; i < 25; i++)
        {
            spaces[i].number = -1;
        }
        for (int i = 0; i < 25; i++)
        {
            int ballCount = 120;
            int nextNum = r.Next((20 * (i % 5)) + 1, (20 * (i % 5)) + 16);
            while(spaces.Any(s => s.number == nextNum))
            {
                nextNum = r.Next((20 * (i % 5)) + 1, (20 * (i % 5)) + 16);
            }
            spaces[i].number = nextNum;
        }
    }
    public void ClearCard()
    {
        foreach(Space s in spaces)
        {
            s.daubed = false;
        }
    }
    public void DaubCard(int ballCount)
    {
        bingoBalls.AddRange(cage.callBalls(ballCount));

        ballText.text = "Balls Drawn: ";
        //Add output of the balls called
        foreach(BingoBall ball in bingoBalls)
        {
            ballText.text += " " + ball.number;
        }

        foreach(Space s in spaces)
        {
            if (bingoBalls.Any(ball => ball.number == s.number))
            {
                s.daubed = true;
            }
        }
    }

    public int CashOutCard()
    {
        ClearCard();
        bingoBalls.Clear();
        int cashedIn = currentWinnings;
        currentWinnings = 0;
        return cashedIn;
    }

    public int getDaubCode()
    {
        int daubCode = 0;
        for(int i = 0; i < spaces.Length; i++)
        {
            if (spaces[i].daubed)
            {
                daubCode += (int)Math.Pow(2, i);
            }
        }
        return daubCode;
    }
    
    public void DisplayWins(List<Evaluator.BingoPattern> wonPatterns)
    {
        string wins = "Wins: ";
        int winnings = 0;
        foreach(Evaluator.BingoPattern pattern in wonPatterns)
        {
            wins+=pattern.name + " at " + pattern.location + ", ";
            currentWinnings += pattern.mult;
        }
        winText.text = wins;
    }
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
