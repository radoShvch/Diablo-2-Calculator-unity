using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rune", menuName ="Rune")]
public class Rune : ScriptableObject
{
    public string name;
    [TextArea]
    public string description;
    public int count = 0;
    public int reqLevel;

    public Sprite icon;


}
