using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.EventSystems;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Controller : MonoBehaviour
{
    public BingoCard card;
    public Evaluator eval;
    public BallCage cage;
    public Gator gator;
    public int tickets = 10; //use these to get keepsakes
    public int credits = 10; //your winnings from the game. Get enough to make it to the next round... (change to int later)
    public int callLimit = 5;
    public int callCount = 5;
    public int callCost = 1; //it costs tickets (or credits) to call balls
    public int ballsPerCall = 10;

    public int maxRounds = 3;
    public int roundCount = 3;
    public int deadline;


    public GameObject shop;
    public TextMeshProUGUI creditText;
    public TextMeshProUGUI callText;
    public KeepsakeFunctions kFunc;
    
    //public GameObject toolTip;


   

    public int keepsakeLimit;
    public List<Keepsake> keepsakes;

    public int roundNumber;
    public int gameCount;
    public int goalAmount;

    public void Play()
    {
        if (callCount == 0)
        {
            return;
        }
        if (callCount == callLimit)
        {
            cage.StartCalls();
        }
        credits -= callCost;
        callCount -= 1;
        card.Play(ballsPerCall);
        KeepsakeTrigger(Keepsake.TriggerPoint.AfterCall);
        UpdateBoards();
    }

    public void CashOut()
    {
        credits += card.CashOutCard();
        callCount = callLimit;
        UpdateBoards();
    }

    public void AddHippo()
    {
        //adds the Hungry Hippo to Keepsakes (for testing)
        Keepsake hippo = new Keepsake(1,"Hungry Hippo","More balls per call",0, 
            new List<Keepsake.TriggerPoint> { Keepsake.TriggerPoint.AfterCall });
        keepsakes.Add(hippo);
    }

    public void UpdateBoards()
    {
        creditText.text = "Credits: " + credits.ToString();
        callText.text = "Calls Remaining: " + callCount.ToString();
    }

    public void KeepsakeTrigger(Keepsake.TriggerPoint triggerPoint)
    {
        foreach (Keepsake k in keepsakes)
        {
            if (k.triggerPoints.Contains(triggerPoint))
            {
                kFunc.KeepsakeFunction(k.id);
            }
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateBoards();
        //keepsakes.Add(new Keepsake(0, "Hungry Hippo", "Get 10 more balls on call", 2, new List<Keepsake.TriggerPoint>()));
    }

    // Update is called once per frame
    void Update()
    {
        //show tooltip
        //input mouse.position
        
        //WORK ON THIS LATER ONCE YOU GET THIS FRONT END BS FIGURED OUT
        /*toolTip.transform.position = Input.mousePosition;
        List<RaycastResult> raycastResults = GetEventSystemRaycastResults();
        bool toolTipFlag = false;
        Keepsake tooltipKeepsake = new Keepsake();
        for (int index = 0; index < raycastResults.Count; index++)
        {
            RaycastResult curRaysastResult = raycastResults[index];
            if (curRaysastResult.gameObject.GetComponent<Keepsake>() != null)
            {
                toolTipFlag = true;
                tooltipKeepsake = curRaysastResult.gameObject.GetComponent<Keepsake>();
            }
        }
        toolTip.SetActive(toolTipFlag);
        if (toolTipFlag)
        {
            toolTip.GetComponentsInChildren<TextMeshProUGUI>().First().text = tooltipKeepsake.name + "\r\r" + tooltipKeepsake.description;
        }*/
    }

    //Gets all event system raycast results of current mouse or touch position.
    static List<RaycastResult> GetEventSystemRaycastResults()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        List<RaycastResult> raysastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raysastResults);
        return raysastResults;
    }
}
