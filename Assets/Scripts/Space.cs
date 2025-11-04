using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Space : MonoBehaviour
{

    public int number;
    public bool daubed;
    public TextMeshPro numText;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        numText.text = number.ToString();
        if (daubed)
        {
            sr.color = Color.cyan;
        }
        else
        {
            sr.color = Color.gray;
        }
    }
}
