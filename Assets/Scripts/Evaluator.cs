using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evaluator : MonoBehaviour
{
    public struct BingoPattern
    {
        public string name;
        public int bitMap;
        public int width;
        public int widthRight; //for stuff like diagonal left (find more graceful solution later?)
        public int mult;
        public int location;
        public List<BingoBall> balls;

        //in the future, there will be implementation for having the Bingo Balls carry their own value that can be changed
        //to do so would DRASTICALLY alter how the math and the sharing of information works.



        public BingoPattern(string name, int pattern, int width, int widthRight, int mult)
        {
            this.name = name;
            this.bitMap = pattern;
            this.width = width;
            this.widthRight = widthRight;
            this.mult = mult;
            this.location = 0;
            this.balls = new List<BingoBall>();
        }

        public BingoPattern(BingoPattern patt, int location)
        {
            this.name = patt.name;
            this.bitMap=patt.bitMap;
            this.width = patt.width;   
            this.widthRight= patt.widthRight;
            this.mult = patt.mult;
            this.location = location;
            this.balls = patt.balls;
        }
    }

    public List<BingoPattern> bingoPatterns = new List<BingoPattern>
    {
        //Our bingo patterns.
        new BingoPattern("2x2 Square",99,2,1,7), //1100011
        new BingoPattern("3x3 Square",7399,3,1,20), //1110011100111
        new BingoPattern("3 Horizontal",7,3,1,2), //111
        new BingoPattern("4 Horizontal",15,4,1,4), //1111
        new BingoPattern("5 Horizontal",31,5,1,10), //11111
        new BingoPattern("3 Vertical",1057,1,1,2), //10000100001
        new BingoPattern("4 Vertical",33825,1,1,4), //1000010000100001
        new BingoPattern("5 Vertical",1082401,1,1,10), //100001000010000100001
        new BingoPattern("3 Diagonal Right",4161,3,1,2), //1000001000001
        new BingoPattern("4 Diagonal Right",266305,4,1,4), //1000001000001000001
        new BingoPattern("5 Diagonal Right",17043521,5,1,10), //1000001000001000001000001
        new BingoPattern("3 Diagonal Left",273,1,3,2), //100010001
        new BingoPattern("4 Diagonal Left",4369,1,4,4), //1000100010001
        new BingoPattern("5 Diagonal Left",34953,1,5,10), //10001000100010001
    };


    //x = 2, y = 0, 1, 2, 3, 5, 6, 7, 8, 10, 11, 12, 13, etc

    public List<BingoPattern> Evaluate(BingoCard card)
    {
        Debug.Log("Evaluating");
        List<BingoPattern> wonPatterns = new List<BingoPattern>();
        int daubCode = card.getDaubCode();
        foreach(BingoPattern pattern in bingoPatterns)
        {
            int pattCode = pattern.bitMap;
            for (int i = 0; i<card.spaces.Length; i++)
            {
                if ((pattern.width - 1 > (24 - i) % 5) || (pattern.widthRight-1 > (i % 5)))
                {
                    pattCode = pattCode << 1;
                    continue;
                }
                int test = daubCode & pattCode;
                if ((daubCode & pattCode) == pattCode)
                {
                    wonPatterns.Add(new BingoPattern(pattern, i));
                }
                pattCode = pattCode << 1;
            }
        }

        return wonPatterns;
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
