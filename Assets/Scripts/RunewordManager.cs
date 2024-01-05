using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RunewordManager : MonoBehaviour
{
    [SerializeField]
    private InputManager managerObj;

    [SerializeField]
    private GameObject runePanel;
    public List<string> _runewordBows = new List<string>();

    public Dropdown runeDropdown;

    public Text runewordDescText;
    public Text runewordLadderText;
    public Text runewordRunesText;

    public Text runewordCountText;
    [SerializeField]
    private Text rwTooltip;
    public Image rwTooltipImage;
    public Button rwTooltipButton;

    private Vector3 runePanelpos1;
    private Vector3 runePanelpos2;
    
    public Runewords[] _all;
    public Runewords[] _bows;
    public Runewords[] _axes;
    public Runewords[] _swords;
    public Runewords[] _clubs;
    public Runewords[] _hammers;
    public Runewords[] _maces;
    public Runewords[] _javelins;
    public Runewords[] _amaSpears;
    public Runewords[] _poles;
    public Runewords[] _spears;
    public Runewords[] _scepters;
    //public Runewords[] _crossbows;
    public Runewords[] _claws;
    public Runewords[] _throwing;
    public Runewords[] _daggers;
    public Runewords[] _staves;

    public Runewords[] _selectedR;

    public List<string> _defaultOptions = new List<string>(); 
    public List<string> _allRunes = new List<string>();
    public List<string> _bowsRunes = new List<string>();
    public List<string> _axesRunes = new List<string>();
    public List<string> _swordsRunes = new List<string>();
    public List<string> _clubsRunes = new List<string>();
    public List<string> _hammersRunes = new List<string>();
    public List<string> _macesRunes = new List<string>();
    public List<string> _javelinsRunes = new List<string>();
    public List<string> _amaSpearsRunes = new List<string>();
    public List<string> _polesRunes = new List<string>();
    public List<string> _spearsRunes = new List<string>();
    public List<string> _sceptersRunes = new List<string>();
    public List<string> _clawsRunes = new List<string>();
    public List<string> _throwingRunes = new List<string>();
    public List<string> _daggersRunes = new List<string>();
    public List<string> _stavesRunes = new List<string>();

    public List<string> _selectedRunewordNames = new List<string>();
    public List<string> _selectedRunes = new List<string>();
    public List<string> _selectedDesc = new List<string>();
    public List<string> _selectedSockets = new List<string>();
    public List<string> _selectedLadder = new List<string>();

    public List<string> _selectedRequiredLevel = new List<string>();
    public List<string> _selectedDetails = new List<string>();

    public Dropdown[] dropdowns;

    void Awake()
    {
        runePanelpos1 = new Vector3(0.0f, -48.0f, 0.0f);
        runePanelpos2 = new Vector3(262.9f, -48.0f, 0.0f);
        _defaultOptions.Add("Select a Weapon Base");
    }
    void Start()
    {
        runewordDescText.gameObject.SetActive(true); 
        runewordLadderText.gameObject.SetActive(false);
        runewordRunesText.gameObject.SetActive(true);
        runewordCountText.gameObject.SetActive(false);
        runeDropdown.ClearOptions();
        runeDropdown.AddOptions(_defaultOptions);
        runeDropdown = GetComponent<Dropdown>();

        managerObj.dropdown = GameObject.Find("Dropdown1").GetComponent<Dropdown>();
        managerObj.dropdownTypes = GameObject.Find("DropdownTypes").GetComponent<Dropdown>();

        rwTooltipImage.gameObject.SetActive(false);
        rwTooltip.gameObject.SetActive(false);

        managerObj.dropdown.onValueChanged.AddListener(delegate
        {
            _selectedDesc.Clear();
            SwitchRuneList(managerObj.dropdown);
        });

        managerObj.dropdownTypes.onValueChanged.AddListener(delegate
        {
            _selectedDesc.Clear();
            SwitchRuneList(managerObj.dropdown);
        });

        runeDropdown.onValueChanged.AddListener(delegate
        {
            SetRunewordTexts();
        });
    }
    private void rwButtonCallback(Button buttonPressed)
    {
        if (buttonPressed == rwTooltipButton)
        {
            rwTooltip.text = "Required Level: " + _selectedRequiredLevel[runeDropdown.value] + "\n" + "Can be made in: " + _selectedDetails[runeDropdown.value];
            rwTooltipImage.gameObject.SetActive(!rwTooltipImage.gameObject.activeSelf);
            rwTooltip.gameObject.SetActive(!rwTooltip.gameObject.activeSelf);
            //runewordLevelText.text = "Required Level: " + _selectedRequiredLevel[runeDropdown.value];
            //runewordDetailsText.text = "Can be made in: " + _selectedDetails[runeDropdown.value];
        }
    }
     void OnEnable()
    {
        rwTooltipButton.onClick.AddListener(() => rwButtonCallback(rwTooltipButton));
    }
     void OnDisable()
    {
        rwTooltipButton.onClick.RemoveAllListeners();
    }
    void Destroy()
    {
        managerObj.dropdown.onValueChanged.RemoveAllListeners();
        managerObj.dropdownTypes.onValueChanged.RemoveAllListeners();
        runeDropdown.onValueChanged.RemoveAllListeners();
    }

    public void SwitchRuneList(Dropdown target)
    {
        CreateRuneLists();
        SetRunewordTexts();
    }
    public void GenerateRunewords(string weapon_Type, Runewords[] runewordGroupList, List<string> runewordHolderList)
    {

        if (managerObj._Selected[managerObj.dropdown.value].weaponType == weapon_Type)
        {
            _selectedR = runewordGroupList;

            foreach (var item in runewordGroupList)
            {
                if (item.runewSockets <= managerObj._Selected[managerObj.dropdown.value].maxSockets)
                {
                    if (runewordHolderList.Contains(item.runewName))
                    {
                        //print("Contains: " + item.runewName);
                        return;
                    }
                    else
                    {
                        //print(item.runewName + " " + item.runewSockets + " Added");
                        runewordHolderList.Add(item.runewName);
                        _selectedDesc.Add(item.runewDesc.Replace("\\n", "\n"));
                        //print(item.runewDesc);
                        _selectedLadder.Add(item.runewLadder);
                        _selectedSockets.Add(item.runewSockets.ToString());
                        _selectedRunes.Add(item.runewRunes);
                        _selectedRequiredLevel.Add(item.runewRequiredLevel.ToString());
                        _selectedDetails.Add(item.runewDetails);
                        //print(item.runewSockets);
                    }
                }
            }

            _selectedRunewordNames = runewordHolderList;
            runeDropdown.AddOptions(_selectedRunewordNames);

            runewordDescText.gameObject.SetActive(true);
            if (_selectedRunewordNames.Count > 0)
            {
                runewordCountText.gameObject.SetActive(true);
                runewordCountText.text = _selectedRunewordNames.Count.ToString();
            }
            // set runeword Count text
            SetRunewordTexts();
        }
    }

    public void CreateRuneLists()
    {
        runeDropdown.ClearOptions();
        
        _bowsRunes.Clear();
        _axesRunes.Clear();
        _swordsRunes.Clear();
        _clubsRunes.Clear();
        _hammersRunes.Clear();
        _macesRunes.Clear();
        _javelinsRunes.Clear();
        _amaSpearsRunes.Clear();
        _polesRunes.Clear();
        _spearsRunes.Clear();
        _sceptersRunes.Clear();
        _clawsRunes.Clear();
        _throwingRunes.Clear();
        _daggersRunes.Clear();
        _stavesRunes.Clear();

        _selectedDesc.Clear();
        _selectedSockets.Clear();
        _selectedLadder.Clear();
        _selectedRunes.Clear();
        _selectedRequiredLevel.Clear();
        _selectedDetails.Clear();

        switch (managerObj._Selected[managerObj.dropdown.value].weaponType)
        {
            
            case "Bows":
                GenerateRunewords("Bows", _bows, _bowsRunes);
                //if (managerObj._Selected[managerObj.dropdown.value].weaponType == "Bows")
                //{
                //    //_selectedDesc.Clear();
                //    //runeDropdown.ClearOptions();
                //    _selectedR = _bows;
                //
                //    foreach (var item in _bows)
                //    {
                //        if (item.runewSockets <= managerObj._Selected[managerObj.dropdown.value].maxSockets)
                //        {
                //            if (_bowsRunes.Contains(item.runewName))
                //            {
                //                print("Contains: " + item.runewName);
                //                return;
                //            }
                //            else
                //            {
                //                print(item.runewName + " " + item.runewSockets + " Added");
                //                _bowsRunes.Add(item.runewName);
                //                _selectedDesc.Add(item.runewDesc.Replace("\\n", "\n"));
                //                print(item.runewDesc);
                //                _selectedLadder.Add(item.runewLadder);
                //                _selectedSockets.Add(item.runewSockets.ToString());
                //                _selectedRunes.Add(item.runewRunes);
                //                print(item.runewSockets);
                //            }
                //        }
                //    }
                //
                //    _selectedRunewordNames = _bowsRunes;
                //    runeDropdown.AddOptions(_selectedRunewordNames);
                //
                //    runewordDescText.gameObject.SetActive(true);
                //    SetRunewordTexts();
                //    //runewordDescText.text = _selectedRunes[runeDropdown.value] + "\n " + _selectedDesc[runeDropdown.value] + "\n " + _selectedRunes2[runeDropdown.value];
                //}
                break;
            // Bows, Axes, Swords_1H, Swords_2H, Clubs, Hammers, Maces, Javelins, Amazon Spears, Polearms, Spears, Scepters, Crossbows, Assassin Katars, Throwing, Daggers, Staves
            case "Axes":
                GenerateRunewords("Axes", _axes, _axesRunes);
                break;
            case "Swords_1H":
                GenerateRunewords("Swords_1H", _swords, _swordsRunes);
                break;
            case "Swords_2H":
                GenerateRunewords("Swords_2H", _swords, _swordsRunes);
                break;
            case "Clubs":
                GenerateRunewords("Clubs", _clubs, _clubsRunes);
                break;
            case "Hammers":
                GenerateRunewords("Hammers", _hammers, _hammersRunes);
                break;
            case "Maces":
                GenerateRunewords("Maces", _maces, _macesRunes);
                break;
            case "Javelins":
                GenerateRunewords("Javelins", _javelins, _javelinsRunes);
                break;
            case "Amazon Spears":
                GenerateRunewords("Amazon Spears", _amaSpears, _amaSpearsRunes);
                break;
            case "Polearms":
                GenerateRunewords("Polearms", _poles, _polesRunes);
                break;
            case "Spears":
                GenerateRunewords("Spears", _spears, _spearsRunes);
                break;
            case "Scepters":
                GenerateRunewords("Scepters", _scepters, _sceptersRunes);
                break;
            case "Crossbows":
                GenerateRunewords("Crossbows", _bows, _bowsRunes);
                break;
            case "Assassin Katars":
                GenerateRunewords("Assassin Katars", _claws, _clawsRunes);
                break;
            case "Throwing":
                GenerateRunewords("Throwing", _throwing, _throwingRunes);
                break;
            case "Daggers":
                GenerateRunewords("Daggers", _daggers, _daggersRunes);
                break;
            case "Staves":
                GenerateRunewords("Staves", _staves, _stavesRunes);
                break;
        }
    }
    public void SwitchRuneInfo(Dropdown target)
    {
        SetRunewordTexts();
    }

    public void SetRunewordTexts()
    {
        if (_selectedRunes.Count > 0)
        {
            runewordRunesText.text = _selectedRunes[runeDropdown.value];

            runewordDescText.text = _selectedDesc[runeDropdown.value];

            if (_selectedLadder[runeDropdown.value].ToString() == "Ladder only")
            {
                runewordLadderText.gameObject.SetActive(true);
                runewordLadderText.text = "(Ladder only)";
            }
            else
            {
                print("Ladder text false");
                runewordLadderText.gameObject.SetActive(false);
            }
        }
        else
        {
            runeDropdown.ClearOptions();
            runeDropdown.AddOptions(_defaultOptions);
            runewordLadderText.gameObject.SetActive(false);
            runewordRunesText.text = "";
            runewordDescText.text = "No available Runewords for this weapon type";
            rwTooltip.text = "";
        }
    }
    
    public void MovePanelLeft()
    {
        runePanel.transform.localPosition = runePanelpos1;
    }
    public void MovePanelRight()
    {
        runePanel.transform.localPosition = runePanelpos2;
    }

}
