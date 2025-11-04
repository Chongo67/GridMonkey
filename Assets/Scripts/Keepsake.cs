using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keepsake : MonoBehaviour
{
    public int id = 0;
    public string keepsakeName = "";
    public string description = "";
    public int cost = 0;
    public int sellValue = 0;
    public List<TriggerPoint> triggerPoints = new List<TriggerPoint>();
    public SpriteRenderer sr;
    public Image image;
    public KeepsakeFunctions k;
    
    

    public enum TriggerPoint
    {
        OnStartOfTurn,
        AfterCall,
        OnCashOut,
        OnTotalScore,
        BeforePatternCheck,
        AfterPatternCheck
    }

    public Keepsake()
    {
        return;
    }

    public Keepsake(int id, string name, string desc, int cost, List<TriggerPoint> points)
    {
        this.id = id;
        this.keepsakeName = name;
        this.description = desc;
        this.cost = cost;
        this.triggerPoints = points;
    }

    public void TriggerKeepsake(TriggerPoint tp)
    {
        k.KeepsakeFunction(id);
    }

    //how do we add the conditional effect?
    //Create a list of "trigger points" (times in a playthrough when the item would trigger)
    //At those points in time, we run a script that checks our keepsakes and sees if they interact with that trigger point
    //A keepsake can have multiple trigger points, each with their own effect
    //Then those keepsakes run their custom scripts at that point in time.
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
