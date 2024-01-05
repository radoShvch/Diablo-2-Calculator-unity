using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunesCounter : MonoBehaviour
{
    public Rune rune;
    public TextMeshProUGUI counterText;
    public int Count
    {
        get { return rune.count; }
        set { rune.count = value; }
    }
    void Start()
    {
        counterText.text = rune.name + " Runes: " + rune.count;
    }

    public void AddCount()
    {
        Count++;
        counterText.text = rune.name + " Runes: " + rune.count;
    }

    public void SubtractCount()
    {
        if(rune.count >=0.1)
        {
            Count--;
            counterText.text = rune.name + " Runes: " + rune.count;
        }
    }


    void Update()
    {
        
    }
}
