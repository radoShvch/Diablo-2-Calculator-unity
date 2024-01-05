using UnityEngine;
using UnityEditor;
using System.IO;

public class CSVtoSO_runewords 
{
    private static string runewordsPath = "/Editor/CSVs/Runewords.csv";
    [MenuItem("Utilities/Generate Runewords")]

    public static void GenerateRunewords()
    {
        string[] allRwLines = File.ReadAllLines(Application.dataPath + runewordsPath);

        foreach (string r in allRwLines)
        {
            string[] splitRwData = r.Split(',');
            Runewords runeword = ScriptableObject.CreateInstance<Runewords>();
            runeword.runewName = splitRwData[0];
            runeword.runewSockets = int.Parse(splitRwData[1]);
            runeword.runewRunes = splitRwData[2];
            runeword.runewDesc = splitRwData[3];
            runeword.runewGroup = splitRwData[4];
            runeword.runewLadder = splitRwData[5];
            runeword.runewOrder = int.Parse(splitRwData[6]);
            runeword.runewDetails = splitRwData[7];
            runeword.runewRequiredLevel = int.Parse(splitRwData[8]);
            runeword.runewBonusMaxEdFloat = float.Parse(splitRwData[9]);
            runeword.runewBonusIASFloat = float.Parse(splitRwData[10]);
            runeword.runewBonusMaxDmgFloat = float.Parse(splitRwData[11]);
            runeword.runewBonusMinDmgFloat = float.Parse(splitRwData[12]);
            runeword.runewBonusMaxFireDmgFloat = float.Parse(splitRwData[13]);
            runeword.runewBonusMinFireDmgFloat = float.Parse(splitRwData[14]);
            runeword.runewBonusMaxColdDmgFloat = float.Parse(splitRwData[15]);
            runeword.runewBonusMinColdDmgFloat = float.Parse(splitRwData[16]);
            runeword.runewBonusMaxLightDmgFloat = float.Parse(splitRwData[17]);
            runeword.runewBonusMinLightDmgFloat = float.Parse(splitRwData[18]);
            runeword.runewBonusPoisonDmgFloat = float.Parse(splitRwData[19]);
            runeword.runewBonusMaxMagicDmgFloat = float.Parse(splitRwData[20]);
            runeword.runewBonusMinMagicDmgFloat = float.Parse(splitRwData[21]);
            runeword.runewBonusStrFloat = float.Parse(splitRwData[22]);
            runeword.runewBonusDexFloat = float.Parse(splitRwData[23]);
            runeword.runewBonusAllAttributeFloat = float.Parse(splitRwData[24]);


            AssetDatabase.CreateAsset(runeword, $"Assets/Runewords/{runeword.runewOrder}_{runeword.runewGroup}_{runeword.runewName}.asset");
        }
        AssetDatabase.SaveAssets();
    }
}
