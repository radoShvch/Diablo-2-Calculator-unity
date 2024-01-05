using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Assets/New Weapon")]
public class Weapon : ScriptableObject
{

    public string weaponName;
    public string weaponType;

    public float minDamage;
    public float maxDamage;

    public float speed;
    public int maxSockets;

    public float reqStr;
    public float reqDex;
    public int weaponIndex;

    public float minDamageThrow;
    public float maxDamageThrow;
    public float minDamageOneHandSword;
    public float maxDamageOneHandSword;
}
