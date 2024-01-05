using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using System.IO;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }
    public Canvas canvasHelper;
    public InputField weaponBonusEdField;
    public InputField gearMaxDmgField;
    // + to min dmg 
    public InputField gearMinDmgField;
    public InputField strTotalField;
    public InputField dexTotalField;
    public InputField gearEdField;
    public InputField gearBonusDmgField;
    // + elemental min dmg 
    public InputField gearBonusDmgMinField;
    //TO DO: hook up the adds damage, gear ed, + to min damage, min elemental damage.

    public InputField addsMinDmgField;
    public InputField addsMaxDmgField;
    

    public Toggle swords1HandDmg; 
    public Toggle throwDmg;
    public Toggle isEthereal;

    public TextMeshProUGUI DexTotal_Text;
    public TextMeshProUGUI StrTotal_Text;
    private string strTotal_String = "Strength";
    private string dexTotal_String = "Dexterity";

    public Text physDamgeResult;
    public Text dexSum;
    public Text oneHandDmg;
    public Text throwDmgText;
    public TextMeshProUGUI insuffStatError;
    [SerializeField]
    private Text wTooltip;
    public Image wTooltipImage;
    public Button wTooltipButton;
    public string insuffStatString = "The {Weapon_Name} requires at least {X} {Stat_Name}";
    public string insuffStatsString = "The {Weapon_Name} requires at least {X} strength and {Y} dexterity";

    public Dropdown dropdown;
    public float ind_Dropdown;

    public Dropdown dropdownTypes;
    public int ind_DropdownT;

    public List<string> weaponNames = new List<string>();
    public List<string> weaponMinDamage = new List<string>();
    public List<string> weaponMaxDamage = new List<string>();

    public List<string> weaponReqStrength = new List<string>();
    public List<string> weaponReqDexterity = new List<string>();

    public List<string> range1 = new List<string>();
    public List<string> range2 = new List<string>();

    public string _selectedName;
    public float baseDamage;
    public float baseMinDamage;
    public float reqStr;
    public float reqDex;
    public float strTotalFloat;
    public float dexTotalFloat;
    public float weaponBonusEdFloat;
    public float gearMaxDmgFloat;
    public float gearEdFloat;
    public float gearBonusDmgFloat;
    public float maxDamageTotal;
    public float physDamgeResultTotal;
    public float physMinDamgeResultTotal;
    //new floats
    public float gearMinDmgFloat;
    public float addsMinDamageFloat;
    public float addsMaxDamageFloat;
    public float gearBonusMinDmgFloat;
    public float ethDamagefloat;


    public Weapon[] _bows;
    public Weapon[] _axes;
    public Weapon[] _swords1H;
    public Weapon[] _swords2H;
    public Weapon[] _clubs;
    public Weapon[] _hammers;
    public Weapon[] _maces;
    public Weapon[] _javelins;
    public Weapon[] _amaSpears;
    public Weapon[] _polearms;
    public Weapon[] _spears;
    public Weapon[] _scepters;
    public Weapon[] _crossbows;
    public Weapon[] _claws;
    public Weapon[] _throwing;
    public Weapon[] _daggers;
    public Weapon[] _staves;

    public Weapon[] _Selected;
    public List<string> _bowsNames = new List<string>();
    public List<string> _axesNames = new List<string>();
    public List<string> _swordsNames1H = new List<string>();
    public List<string> _swordsNames2H = new List<string>();
    public List<string> _clubsNames = new List<string>();
    public List<string> _hammersNames = new List<string>();
    public List<string> _macesNames = new List<string>();
    public List<string> _javelinsNames = new List<string>();
    public List<string> _amaSpearsNames = new List<string>();
    public List<string> _polearmsNames = new List<string>();
    public List<string> _spearsNames = new List<string>();
    public List<string> _sceptersNames = new List<string>();

    public List<string> _crossbowsNames = new List<string>();
    public List<string> _clawsNames = new List<string>();
    public List<string> _throwingNames = new List<string>();
    public List<string> _daggersNames = new List<string>();
    public List<string> _stavesNames = new List<string>();

    private void Awake()
    {
        Instance = this;
    }
    void Start() 
    {
        foreach (var item in _bows)
        {
            _bowsNames.Add(item.weaponName);
        }

        dropdown = GetComponent<Dropdown>();
        dropdown.ClearOptions();
        dropdown.AddOptions(_bowsNames);

        foreach (var item in _axes)
        {
            _axesNames.Add(item.weaponName);
        }
        foreach (var item in _swords1H)
        {
            _swordsNames1H.Add(item.weaponName);
        }
        foreach (var item in _swords2H)
        {
            _swordsNames2H.Add(item.weaponName);
        }
        foreach (var item in _clubs)
        {
            _clubsNames.Add(item.weaponName);
        }
        foreach (var item in _hammers)
        {
            _hammersNames.Add(item.weaponName);
        }
        foreach (var item in _maces)
        {
            _macesNames.Add(item.weaponName);
        }
        foreach (var item in _javelins)
        {
            _javelinsNames.Add(item.weaponName);
        }
        foreach (var item in _amaSpears)
        {
            _amaSpearsNames.Add(item.weaponName);
        }
        foreach (var item in _polearms)
        {
            _polearmsNames.Add(item.weaponName);
        }
        foreach (var item in _spears)
        {
            _spearsNames.Add(item.weaponName);
        }
        foreach (var item in _scepters)
        {
            _sceptersNames.Add(item.weaponName);
        }
        foreach (var item in _crossbows)
        {
            _crossbowsNames.Add(item.weaponName);
        }
        foreach (var item in _claws)
        {
            _clawsNames.Add(item.weaponName);
        }
        foreach (var item in _throwing)
        {
            _throwingNames.Add(item.weaponName);
        }
        foreach (var item in _daggers)
        {
            _daggersNames.Add(item.weaponName);
        }
        foreach (var item in _staves)
        {
            _stavesNames.Add(item.weaponName);
        }

        ind_Dropdown = dropdown.value;
        dropdownTypes = GameObject.Find("DropdownTypes").GetComponent<Dropdown>();

        wTooltip = GameObject.Find("weaponTooltip_Text").GetComponent<Text>();

        wTooltipImage.gameObject.SetActive(false);
        wTooltip.gameObject.SetActive(false);

        SwitchFiles(dropdownTypes);

        _Selected = _bows;

        dropdownTypes.onValueChanged.AddListener(delegate
        {
            SwitchFiles(dropdownTypes);
        });

    }
   
    private void buttonCallBack(Button buttonPressed)
    {
        if (buttonPressed == wTooltipButton)
        {
            wTooltip.text = "Base Damage: " + _Selected[dropdown.value].minDamage + "-" + _Selected[dropdown.value].maxDamage + "\n" + "Weapon Speed: " + _Selected[dropdown.value].speed + "\n" + "Max sockets: " + _Selected[dropdown.value].maxSockets;
            wTooltipImage.gameObject.SetActive(!wTooltipImage.gameObject.activeSelf);
            wTooltip.gameObject.SetActive(!wTooltip.gameObject.activeSelf);
        }
    }
    void OnEnable()
    {
        //Register Button Events
        wTooltipButton.onClick.AddListener(() => buttonCallBack(wTooltipButton));
    }
    void OnDisable()
    {
        //Un-Register Button Events
        wTooltipButton.onClick.RemoveAllListeners();
    }
    void Destroy()
    {
        dropdownTypes.onValueChanged.RemoveAllListeners();
    }
    private void ShowThrowToggle(int i)
    {
        if (i > 0)
        {

            throwDmg.gameObject.SetActive(true);
        }
        else
        {
            throwDmg.gameObject.SetActive(false);
            throwDmgText.gameObject.SetActive(false);
        }
    }
    private void SwitchFiles(Dropdown target)
    {
        dropdown.ClearOptions();
        if (dropdownTypes.value == 0)
        {
            dropdown.AddOptions(_bowsNames);
            _Selected = _bows;
            ShowDexterityText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 1)
        {
            dropdown.AddOptions(_axesNames);
            _Selected = _axes;
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 2)
        {
            _Selected = _swords1H;
            dropdown.AddOptions(_swordsNames1H);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 3)
        {
            _Selected = _swords2H;
            dropdown.AddOptions(_swordsNames2H);
            ShowStrengthText();
            ShowThrowToggle(0);
            swords1HandDmg.gameObject.SetActive(true);

        }
        else
        {
            swords1HandDmg.gameObject.SetActive(false);
            oneHandDmg.gameObject.SetActive(false);
        }
        if (dropdownTypes.value == 4)
        {
            _Selected = _clubs;
            dropdown.AddOptions(_clubsNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 5)
        {
            _Selected = _hammers;
            dropdown.AddOptions(_hammersNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 6)
        {
            _Selected = _maces;
            dropdown.AddOptions(_macesNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 7)
        {
            _Selected = _javelins;
            dropdown.AddOptions(_javelinsNames);
            //ShowStrengthText();
            ShowStrengthAndDexterityText();
            ShowThrowToggle(1);
            //throwDmg.gameObject.SetActive(true);
        }
      
        if (dropdownTypes.value == 8)
        {
            _Selected = _amaSpears;
            dropdown.AddOptions(_amaSpearsNames);
            ShowStrengthAndDexterityText();
            ShowThrowToggle(1);
        }
        if (dropdownTypes.value == 9)
        {
            _Selected = _polearms;
            dropdown.AddOptions(_polearmsNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 10)
        {
            _Selected = _spears;
            dropdown.AddOptions(_spearsNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 11)
        {
            _Selected = _scepters;
            dropdown.AddOptions(_sceptersNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 12)
        {
            _Selected = _crossbows;
            dropdown.AddOptions(_crossbowsNames);
            ShowDexterityText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 13)
        {
            _Selected = _claws;
            dropdown.AddOptions(_clawsNames);
            ShowStrengthAndDexterityText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 14)
        {
            _Selected = _throwing;
            dropdown.AddOptions(_throwingNames);
            ShowStrengthAndDexterityText();
            ShowThrowToggle(2);
            //throwDmg.gameObject.SetActive(true);
        }
        
        if (dropdownTypes.value == 15)
        {
            _Selected = _daggers;
            dropdown.AddOptions(_daggersNames);
            ShowStrengthAndDexterityText();
            ShowThrowToggle(0);
        }
        if (dropdownTypes.value == 16)
        {
            _Selected = _staves;
            dropdown.AddOptions(_stavesNames);
            ShowStrengthText();
            ShowThrowToggle(0);
        }
    }
   
    private void ShowStrengthText()
    {
        //DexTotal_Text.gameObject.SetActive(false);
        StrTotal_Text.gameObject.SetActive(true);
        StrTotal_Text.text = strTotal_String;
        //canvasHelper.transform.localPosition = new Vector3(0.0f, -38.0f, 0.0f);
        //dexTotalField.gameObject.SetActive(false);
        strTotalField.gameObject.SetActive(true);
    }
    private void ShowDexterityText()
    {
        //StrTotal_Text.gameObject.SetActive(false);
        DexTotal_Text.gameObject.SetActive(true);
        DexTotal_Text.text = dexTotal_String;
        //canvasHelper.transform.localPosition = new Vector3(0.0f, -38.0f, 0.0f);
        //strTotalField.gameObject.SetActive(false);
        dexTotalField.gameObject.SetActive(true);
    }
    private void ShowStrengthAndDexterityText()
    {
        dexTotalField.gameObject.SetActive(true);
        strTotalField.gameObject.SetActive(true);
        DexTotal_Text.gameObject.SetActive(true);
        StrTotal_Text.gameObject.SetActive(true);
        //canvasHelper.transform.localPosition = new Vector3(0.0f, -78.0f, 0.0f);
    }

    private void FixedUpdate()
    {
        TestMethod();

    void TestMethod()
        {
            string _selectedName = _Selected[dropdown.value].weaponName.ToString();
            float baseMinDamage = _Selected[dropdown.value].minDamage;
            float baseDamage = _Selected[dropdown.value].maxDamage;
            float reqStr = _Selected[dropdown.value].reqStr;
            float reqDex = _Selected[dropdown.value].reqDex;
            float skillEdFloat = 0;

            //float strTotalFloat = float.Parse(strTotalField.text);
            //float dexTotalFloat = float.Parse(dexTotalField.text);
            float.TryParse(strTotalField.text, out strTotalFloat);
            float.TryParse(dexTotalField.text, out dexTotalFloat);

            //float weaponBonusEdFloat = float.Parse(weaponBonusEdField.text);
            //float gearEdFloat = float.Parse(gearEdField.text);
            float.TryParse(weaponBonusEdField.text, out weaponBonusEdFloat);
            float.TryParse(gearEdField.text, out gearEdFloat);

            //float gearMaxDmgFloat = float.Parse(gearMaxDmgField.text);
            float.TryParse(gearMaxDmgField.text, out gearMaxDmgFloat);
            float.TryParse(gearMinDmgField.text, out gearMinDmgFloat);

            float.TryParse(addsMinDmgField.text, out addsMinDamageFloat);
            float.TryParse(addsMaxDmgField.text, out addsMaxDamageFloat);


            //float gearBonusDmgFloat = float.Parse(gearBonusDmgField.text);
            float.TryParse(gearBonusDmgField.text, out gearBonusDmgFloat);
            float.TryParse(gearBonusDmgMinField.text, out gearBonusMinDmgFloat);

            float maxDamageTotal = (gearMaxDmgFloat + (baseDamage + (weaponBonusEdFloat / 100 * baseDamage)));
            float maxDmgTotalNew = (baseDamage*(1+ weaponBonusEdFloat/100)+ gearMaxDmgFloat);
            //
            //print("maxDmgTotal: " + maxDmgTotalNew);
            float physDamgeResultTotalNew = (maxDmgTotalNew*(1+ strTotalFloat*1/100 + dexTotalFloat*0/100));
            //print("Final Dmg no elem dmg: " + (physDamgeResultTotalNew+gearBonusDmgFloat));
            //float physDamgeResultTotal = gearBonusDmgFloat + maxDamageTotal + (maxDamageTotal * ((dexTotalFloat + gearEdFloat) / 100));
            dexSum.text = "Physical Damage:" + Mathf.Floor(physMinDamgeResultTotal).ToString("#") + "-" + Mathf.Floor(physDamgeResultTotal).ToString("#");
            //((baseDamage*(1+ weaponBonusEdFloat/100)+ gearMaxDmgFloat)*(1+ strTotalFloat*1/100 + dexTotalFloat*0/100))+gearBonusDmgFloat 


            void InsuffStrengthError()
            {
                insuffStatError.gameObject.SetActive(true);
                insuffStatError.text = insuffStatString.Replace("{X}", reqStr.ToString()).Replace("{Weapon_Name}", _selectedName).Replace("{Stat_Name}", "strength");
            }
            void InsuffDexterityError()
            {
                insuffStatError.gameObject.SetActive(true);
                insuffStatError.text = insuffStatString.Replace("{X}", reqDex.ToString()).Replace("{Weapon_Name}", _selectedName).Replace("{Stat_Name}", "dexterity");
            }
            void InsuffStrengthDexterityError()
            {
                insuffStatError.gameObject.SetActive(true);
                insuffStatError.text = insuffStatsString.Replace("{X}", reqStr.ToString()).Replace("{Y}", reqDex.ToString()).Replace("{Weapon_Name}", _selectedName);
            }
            void IsEtheral()
            {
                if (isEthereal.isOn)
                {
                    ethDamagefloat = 1.5f;
                }
                else { ethDamagefloat = 1.0f; } 
            }

            float GetScaling(float strScaling, float dexScaling){
                float scaling = Mathf.Round(((1 + strTotalFloat * strScaling / 100 + dexTotalFloat * dexScaling / 100) + (gearEdFloat + skillEdFloat) / 100) * 100) / 100;
                return scaling;
            }
            float GetBaseMaxDmg(float baseMaxDamageValue)
            {
                IsEtheral();
                float baseMaxDmg = Mathf.Floor((baseMaxDamageValue * ethDamagefloat) * (1 + weaponBonusEdFloat / 100) + (gearMaxDmgFloat + addsMaxDamageFloat));
                return baseMaxDmg;
            }
            float GetBaseMinDmg(float baseMinDamageValue)
            {
                IsEtheral();
                float baseMinDmg = Mathf.Floor((baseMinDamageValue * ethDamagefloat) * (1 + weaponBonusEdFloat / 100) + (gearMinDmgFloat + addsMinDamageFloat));
                return baseMinDmg;
            }

            switch (dropdownTypes.value)
            {
                case 0:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage)  * GetScaling(0f, 1f) +gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0f, 1f) + gearBonusMinDmgFloat;

                    if (dexTotalFloat < reqDex)
                    {
                        InsuffDexterityError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                        break;
                
                case 1:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 2:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if ((dexTotalFloat < reqDex) && (strTotalFloat < reqStr))
                    {
                        InsuffStrengthDexterityError();
                    }
                    else if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 3:

                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (swords1HandDmg.isOn)
                    {
                        float baseMaxDamage1Hand = _Selected[dropdown.value].maxDamageOneHandSword;
                        float baseMinDamage1Hand = _Selected[dropdown.value].minDamageOneHandSword;
                        // baseMaxDamage1Hand baseMinDamage1Hand
                        float physMaxDamgeResultTotal1Hand = GetBaseMaxDmg(baseMaxDamage1Hand) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                        float physMinDamgeResultTotal1Hand = GetBaseMinDmg(baseMinDamage1Hand) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                        //float physMaxDamgeResultTotal1Hand = ((baseMaxDamage1Hand * (1 + weaponBonusEdFloat / 100) + gearMaxDmgFloat) * (1 + strTotalFloat * 1 / 100 + dexTotalFloat * 0 / 100)) + gearBonusDmgFloat;
                        oneHandDmg.gameObject.SetActive(true);
                        oneHandDmg.text = "One-Handed Damage:" + Mathf.Floor(physMinDamgeResultTotal1Hand).ToString("#") +"-"+ Mathf.Floor(physMaxDamgeResultTotal1Hand).ToString("#");
                    }
                    else
                    {
                        oneHandDmg.gameObject.SetActive(false);
                    }
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 4:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 5:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1.10f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1.10f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 6:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 7:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(0.75f, 0.75f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0.75f, 0.75f) + gearBonusMinDmgFloat;
                    if (throwDmg.isOn)
                    {
                        float baseMaxThrowDamage = _Selected[dropdown.value].maxDamageThrow;
                        float baseMinThrowDamage = _Selected[dropdown.value].minDamageThrow;

                        float physMaxDamgeResultTotalThrow = GetBaseMaxDmg(baseMaxThrowDamage) * GetScaling(0.75f, 0.75f) + gearBonusDmgFloat; ;
                        float physMinDamgeResultTotalThrow = GetBaseMinDmg(baseMinThrowDamage) * GetScaling(0.75f, 0.75f) + gearBonusMinDmgFloat;
                        throwDmgText.gameObject.SetActive(true);
                        throwDmgText.text = "Throw Damage: " + Mathf.Floor(physMinDamgeResultTotalThrow).ToString("#") +"-"+ Mathf.Floor(physMaxDamgeResultTotalThrow).ToString("#");
                    }
                    else
                    {
                        throwDmgText.gameObject.SetActive(false);
                    }
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 8:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(0.80f, 0.50f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0.80f, 0.50f) + gearBonusMinDmgFloat;
                    if (throwDmg.isOn)
                    {

                        float baseMaxThrowDamage = _Selected[dropdown.value].maxDamageThrow;
                        float baseMinThrowDamage = _Selected[dropdown.value].minDamageThrow;

                        float physMaxDamgeResultTotalThrow = GetBaseMaxDmg(baseMaxThrowDamage) * GetScaling(0.80f, 0.50f) + gearBonusDmgFloat; ;
                        float physMinDamgeResultTotalThrow = GetBaseMinDmg(baseMinThrowDamage) * GetScaling(0.80f, 0.50f) + gearBonusMinDmgFloat;
                        throwDmgText.gameObject.SetActive(true);
                        if (baseMaxThrowDamage > 0)
                        {
                            throwDmgText.text = "Throw Damage: " + Mathf.Floor(physMinDamgeResultTotalThrow).ToString("#") + "-" + Mathf.Floor(physMaxDamgeResultTotalThrow).ToString("#");
                        }
                        else
                        {
                            throwDmgText.text = "Cannot be thrown";
                        }
                    }
                    else
                    {
                        throwDmgText.gameObject.SetActive(false);
                    }
                    if ((dexTotalFloat < reqDex) && (strTotalFloat < reqStr))
                    {
                        InsuffStrengthDexterityError();
                    }
                    else if (dexTotalFloat < reqDex)
                    {
                        InsuffDexterityError();
                    }
                    else if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 9:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 10:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 11:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 12:
                    //crossbows
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(0f, 1f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0f, 1f) + gearBonusMinDmgFloat;
                    if (dexTotalFloat < reqDex)
                    {
                        InsuffDexterityError();

                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 13:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(0.75f, 0.75f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0.75f, 0.75f) + gearBonusMinDmgFloat;
                    if ((dexTotalFloat < reqDex) && (strTotalFloat < reqStr))
                    {
                        InsuffStrengthDexterityError();
                    }
                    else if (dexTotalFloat < reqDex)
                    {
                        InsuffDexterityError();
                    }
                    else if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 14:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(0.75f, 0.75f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0.75f, 0.75f) + gearBonusMinDmgFloat;
                    if (throwDmg.isOn)
                    {
                        float baseMaxThrowDamage = _Selected[dropdown.value].maxDamageThrow;
                        float baseMinThrowDamage = _Selected[dropdown.value].minDamageThrow;
                        float physMaxDamgeResultTotalThrow = GetBaseMaxDmg(baseMaxThrowDamage) * GetScaling(0.80f, 0.50f) + gearBonusDmgFloat; ;
                        float physMinDamgeResultTotalThrow = GetBaseMinDmg(baseMinThrowDamage) * GetScaling(0.80f, 0.50f) + gearBonusMinDmgFloat;
                        throwDmgText.gameObject.SetActive(true);
                        throwDmgText.text = "Throw Damage: " + Mathf.Floor(physMinDamgeResultTotalThrow).ToString("#") + "-" + Mathf.Floor(physMaxDamgeResultTotalThrow).ToString("#");
                    }
                    else
                    {
                        throwDmgText.gameObject.SetActive(false);
                    }
                    if ((dexTotalFloat < reqDex) && (strTotalFloat < reqStr))
                    {
                        InsuffStrengthDexterityError();
                    }
                    else if (dexTotalFloat < reqDex)
                    {
                        InsuffDexterityError();
                    }
                    else if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 15:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(0.75f, 0.75f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(0.75f, 0.75f) + gearBonusMinDmgFloat;
                    if ((dexTotalFloat < reqDex) && (strTotalFloat < reqStr))
                    {
                        InsuffStrengthDexterityError();
                    }
                    else if (dexTotalFloat < reqDex)
                    {
                        InsuffDexterityError();
                    }
                    else if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
                case 16:
                    physDamgeResultTotal = GetBaseMaxDmg(baseDamage) * GetScaling(1f, 0f) + gearBonusDmgFloat;
                    physMinDamgeResultTotal = GetBaseMinDmg(baseMinDamage) * GetScaling(1f, 0f) + gearBonusMinDmgFloat;
                    if (strTotalFloat < reqStr)
                    {
                        InsuffStrengthError();
                    }
                    else
                    {
                        insuffStatError.gameObject.SetActive(false);
                    }
                    break;
            }


        }
            
        
    }
    
}
