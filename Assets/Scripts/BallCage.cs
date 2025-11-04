using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallCage : MonoBehaviour
{
    public List<BingoBall> bingoBalls = new List<BingoBall>();
    public System.Random r = new System.Random();
    public BingoCard card;

    public List<BingoBall> returnBalls;
    public List<BingoBall> cloneBalls;
    public BallCage()
    {
        for (int i = 1; i <= 100; i++)
        {
            bingoBalls.Add(new BingoBall(i));
        }
    }
    public void StartCalls()
    {
        cloneBalls = new List<BingoBall>(bingoBalls);
    }

    public List<BingoBall> callBalls(int count)
    {
        returnBalls = new List<BingoBall>();
        for (int i = 0; i < count; i++)
        {
            int rand = r.Next(cloneBalls.Count);
            while(returnBalls.Any(ball=>ball.number == rand))
            {
                rand = r.Next (cloneBalls.Count);
            }
            returnBalls.Add(cloneBalls[rand]);
            cloneBalls.Remove(cloneBalls[rand]);
        }
        return returnBalls;
    }


    // Start is called before the first frame update
    void Start()
    {
        for(int i = 1; i <= 70; i++)
        {
            bingoBalls.Add(new BingoBall(i));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
