using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownTypes : MonoBehaviour
{
    public Dropdown dropdownTypes;
    public int ind_DropdownTypes;
    public List<string> weaponTypes = new List<string>();

    void Start()
    {
        weaponTypes.Add("Bows");
        weaponTypes.Add("Axes");
        weaponTypes.Add("Swords One-Handed");
        weaponTypes.Add("Swords Two-Handed");
        weaponTypes.Add("Clubs");
        weaponTypes.Add("Hammers");
        weaponTypes.Add("Maces");
        weaponTypes.Add("Javelins");
        weaponTypes.Add("Amazon Spears");
        weaponTypes.Add("Polearms");
        weaponTypes.Add("Spears");
        weaponTypes.Add("Scepters");
        weaponTypes.Add("Crossbows");
        weaponTypes.Add("Assassin Claws");
        weaponTypes.Add("Throwing Weapons");
        weaponTypes.Add("Daggers");
        weaponTypes.Add("Staves");

        dropdownTypes.ClearOptions();
        dropdownTypes.AddOptions(weaponTypes);
        dropdownTypes = GetComponent<Dropdown>();
        //Debug.Log("Starting tmp_Dropdown value: " + dropdownTypes.value);
        ind_DropdownTypes = dropdownTypes.value;


    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < weaponTypes.Count; i++)
            {
                Debug.Log(weaponTypes[i]);
            }
            
        }
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
             
        }
        }
    }
