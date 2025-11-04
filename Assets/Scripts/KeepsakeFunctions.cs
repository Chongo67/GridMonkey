using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepsakeFunctions : MonoBehaviour
{
    public Controller controller;





    public void KeepsakeFunction(int id)
    {
        //So I'm thinking later on, I'm going to implement these as delegates.
        //But right now I'm just doin something quick and nasty, so
        //switch case it is!
        switch (id)
        {
            case 1: //Hungry Hippo. More Balls per call!
                controller.card.Play(2);
                break;
        }
                
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
