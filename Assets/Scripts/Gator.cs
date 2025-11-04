using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gator : MonoBehaviour
{
    // Start is called before the first frame update
    public int numSpins = 100000;
    public int count = 0;
    public Controller controller;
    public int winnings = 0;
    public TextMeshPro output;


    public void GatorActivate()
    {
        winnings = 0;
        count = 0;
        for(int i = 0; i<numSpins; i++)
        {
            controller.Play();
        }
        return;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
