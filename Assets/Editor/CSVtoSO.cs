using UnityEngine;
using UnityEditor;
using System.IO;


public class CSVtoSO
{
    private static string weaponCSVpath = "/Editor/CSVs/WeaponsBlunt.csv";
    [MenuItem("Utilities/Generate Weapons")]
    public static void GenerateWeapons()
    {
        string[] allLines = File.ReadAllLines(Application.dataPath + weaponCSVpath);

        foreach (string s in allLines)
        {
            string[] splitData = s.Split(',');

            Weapon weapon = ScriptableObject.CreateInstance<Weapon>();
            weapon.weaponName = splitData[0];
            weapon.weaponType = splitData[1];
            weapon.minDamage = float.Parse(splitData[2]);
            weapon.maxDamage = float.Parse(splitData[3]);

            weapon.speed = float.Parse(splitData[4]);
            weapon.maxSockets = int.Parse(splitData[5]);

            weapon.reqStr = float.Parse(splitData[6]);
            weapon.reqDex = float.Parse(splitData[7]);
            weapon.weaponIndex = int.Parse(splitData[8]);

            weapon.minDamageThrow = float.Parse(splitData[9]);
            weapon.maxDamageThrow = float.Parse(splitData[10]);

            weapon.minDamageOneHandSword = float.Parse(splitData[11]);
            weapon.maxDamageOneHandSword = float.Parse(splitData[12]);



            AssetDatabase.CreateAsset(weapon, $"Assets/Weapons/{weapon.weaponType}_{weapon.weaponIndex}.asset");
        }
        AssetDatabase.SaveAssets();
    }
}
