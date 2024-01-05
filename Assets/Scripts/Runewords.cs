using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Runeword", menuName = "Assets/New Runeword")]
public class Runewords : ScriptableObject
{
    // name	sockets 	runes	desc	group	ladder
    public string runewName; 
    public int runewSockets;
    public string runewRunes;
    [TextArea]
    public string runewDesc;
    public string runewGroup;
    public string runewLadder;

    public int runewOrder;
    public string runewDetails;

    public int runewRequiredLevel;

    public float runewBonusMaxEdFloat;
    public float runewBonusIASFloat;
    public float runewBonusMaxDmgFloat;
    public float runewBonusMinDmgFloat;
    public float runewBonusMaxFireDmgFloat;
    public float runewBonusMinFireDmgFloat;
    public float runewBonusMaxColdDmgFloat;
    public float runewBonusMinColdDmgFloat;
    public float runewBonusMaxLightDmgFloat;
    public float runewBonusMinLightDmgFloat;
    public float runewBonusPoisonDmgFloat;
    public float runewBonusMaxMagicDmgFloat;
    public float runewBonusMinMagicDmgFloat;
    public float runewBonusStrFloat;
    public float runewBonusDexFloat;
    public float runewBonusAllAttributeFloat;
}
