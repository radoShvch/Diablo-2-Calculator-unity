using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DropdownBreakpoints : MonoBehaviour
{
    public Dropdown dropdownBpts;
    public int ind_DropdownBpts;
    public List<string> classTypes = new List<string>();
    public GameObject contentFitter;

    public TextMeshProUGUI fhrText; 
    public TextMeshProUGUI fcrText;
    public TextMeshProUGUI fbrText;

    public TextMeshProUGUI fhrText2;
    public TextMeshProUGUI fcrText2;
    public TextMeshProUGUI fbrText2;

    public TextMeshProUGUI fhrText3;
    public TextMeshProUGUI fcrText3;
    public TextMeshProUGUI fbrText3;

    public TextMeshProUGUI fhrText4;
    public TextMeshProUGUI fbrTitleText;

    void Start()
    {
        classTypes.Add("Amazon");
        classTypes.Add("Assassin");
        classTypes.Add("Barbarian");
        classTypes.Add("Druid");
        classTypes.Add("Necromancer");
        classTypes.Add("Paladin");
        classTypes.Add("Sorceress");
        classTypes.Add("Mercenaries");

        dropdownBpts.ClearOptions();
        dropdownBpts.AddOptions(classTypes);
        dropdownBpts = GetComponent<Dropdown>();
        ind_DropdownBpts = dropdownBpts.value;

        //fhrText.text = fhrString;
        //fcrText.text = fcrString;
        //fbrText.text = fbrString;

        fhrText.text = "FHR Frames\n0% 11\n6% 10\n13% 9\n20% 8\n32% 7\n52% 6\n86% 5\n174% 4\n 600% 3";
        fcrText.text = "FCR Frames\n0% 19\n7% 18\n14% 17\n22% 16\n32% 15\n48% 14\n68% 13\n99% 12\n 152% 11";
        fbrText.text = "Amazon hit by a 1-handed weapon\nFBR Frames\n0% 17\n4% 16\n6% 15\n11% 14\n15% 13\n23% 12\n29% 11\n40% 10\n 56% 9\n 80% 8\n 120% 7\n 200% 6\n 480% 5"; // Amazon hit by a 1-handed 
        fbrText2.text = "Amazon hit by any other weapon\nFBR Frames\n0% 5\n13% 4\n32% 3\n86% 2\n600% 1"; //Amazon hit by any other weapon

        fhrText2.text = "";
        fcrText2.text = "";
        fhrText3.text = "";
        fcrText3.text = "";
        fbrText3.text = "";
        fhrText4.text = "";
        dropdownBpts.onValueChanged.AddListener(delegate
        {
            SwitchBreakpoints(dropdownBpts);
        });
        
    }
    private void ShowBlockRateTitle(bool shouldshow)
    {
        fbrTitleText.gameObject.SetActive(shouldshow);
    }

    private void SwitchBreakpoints(Dropdown target)
    {
        switch (dropdownBpts.value)
        {
            case 0:
                //Amazon
                fhrText.text = "FHR Frames\n0% 11\n6% 10\n13% 9\n20% 8\n32% 7\n52% 6\n86% 5\n174% 4\n 600% 3\n";
                fcrText.text = "FCR Frames\n0% 19\n7% 18\n14% 17\n22% 16\n32% 15\n48% 14\n68% 13\n99% 12\n 152% 11\n";
                fbrText.text = "Amazon hit by a 1-handed weapon\nFBR Frames\n0% 17\n4% 16\n6% 15\n11% 14\n15% 13\n23% 12\n29% 11\n40% 10\n 56% 9\n 80% 8\n 120% 7\n 200% 6\n 480% 5\n"; // Amazon hit by a 1-handed 
                fbrText2.text = "Amazon hit by any other weapon\nFBR Frames\n0% 5\n13% 4\n32% 3\n86% 2\n600% 1"; //Amazon hit by any other weapon

                fhrText2.text = "";
                fcrText2.text = "";
                fhrText3.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                fhrText4.text = "";
                ShowBlockRateTitle(true);
                break;
            case 1:
                //Assassin
                fhrText.text = "FHR Frames\n0% 9\n7% 8\n15% 7\n27% 6\n48% 5\n86% 4\n200% 3\n4680% 2";
                fcrText.text = "FCR Frames\n0% 16\n8% 15\n16% 14\n27% 13\n42% 12\n65% 11\n102% 10\n174% 9";
                fbrText.text = "FBR Frames\n0% 5\n13% 4\n32% 3\n86% 2\n600% 1";
                fhrText2.text = "";
                fcrText2.text = "";
                fbrText2.text = "";
                fhrText3.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                fhrText4.text = "";
                ShowBlockRateTitle(true);
                break;
            case 2:
                //Barbarian
                fhrText.text = "FHR Frames\n0% 9\n7% 8\n15% 7\n27% 6\n48% 5\n86% 4\n200% 3\n4680% 2";
                fcrText.text = "FCR Frames\n0% 13\n9% 12\n20% 11\n37% 10\n63% 9\n105% 8\n200% 7";
                fbrText.text = "FBR Frames\n0% 7\n9% 6\n20% 5\n42% 4\n86% 3\n280% 2";
                fhrText2.text = "";
                fcrText2.text = "";
                fbrText2.text = "";
                fhrText3.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                fhrText4.text = "";
                ShowBlockRateTitle(true);
                break;
            case 3:
                //Druid
                fhrText.text = "Druid hit by a 1-handed weapon\nFHR Frames\n0% 14\n3% 13\n7% 12\n13% 11\n19% 10\n29% 9\n42% 8\n63% 7\n99% 6\n174% 5\n456% 4"; // Druid *) hit by a 1-handed weapon
                fhrText2.text = "Druid hit by any other weapon\nFHR Frames\n0% 13\n5% 12\n10% 11\n16% 10\n26% 9\n39% 8\n56% 7\n86% 6\n152% 5\n377% 4"; //Druid **) hit by any other weapon
                fhrText3.text = "Druid (Wolf form)\nFHR Frames\n0% 7\n9% 6\n20% 5\n42% 4\n86% 3\n280% 2"; // Druid (Wolf form)
                fhrText4.text = "Druid (Bear form)\nFHR Frames\n0% 13\n5% 12\n10% 11\n16% 10\n24% 9\n37% 8\n54% 7\n86% 6\n152% 5\n360% 4"; // Druid (Wolf form)

                fcrText.text = "Druid (Human form)\nFCR Frames\n0% 18\n4% 17\n10% 16\n19% 15\n30% 14\n46% 13\n68% 12\n99% 11\n163% 10"; // Druid (Human form)
                fcrText2.text = "Druid (Wolf form)\nFCR Frames\n0% 16\n6% 15\n14% 14\n26% 13\n40% 12\n60% 11\n95% 10\n157% 9";// Druid (Wolf form)
                fcrText3.text = "Druid (Bear form)\nFCR Frames\n0% 16\n7% 15\n15% 14\n26% 13\n40% 12\n63% 11\n95% 10\n163% 9";// Druid (Bear form)

                fbrText.text = "Druid (Human form)\nFBR Frames\n0% 11\n6% 10\n13% 9\n20% 8\n32% 7\n52% 6\n86% 5\n174% 4\n600% 3";// Druid (Human form)
                fbrText2.text = "Druid (Wolf form)\nFBR Frames\n0% 9\n7% 8\n15% 7\n27% 6\n48% 5\n86% 4\n200% 3";// Druid (Wolf form)
                fbrText3.text = "Druid (Bear form)\nFBR Frames\n0% 12\n5% 11\n10% 10\n16% 9\n27% 8\n40% 7\n65% 6\n109% 5\n223% 4";// Druid (Bear form)
                ShowBlockRateTitle(true);
                break;
            case 4:
                //Necromancer
                fhrText.text = "FHR Frames\n0% 13\n5% 12\n10% 11\n16% 10\n26% 9\n39% 8\n56% 7\n86% 6\n152% 5\n377% 4";
                fcrText.text = "FCR Frames\n0% 15\n9% 14\n18% 13\n30% 12\n48% 11\n75% 10\n125% 9";
                fcrText2.text = "Vampire form\nFCR Frames\n0% 23\n6% 22\n11% 21\n18% 20\n24% 19\n35% 18\n48% 17\n65% 16\n86% 15\n120% 14\n180% 13"; // Ghoul/Vampire form 
                fbrText.text = "FBR Frames\n0% 11\n6% 10\n13% 9\n20% 8\n32% 7\n52% 6\n86% 5\n174% 4\n600% 3";
                fhrText2.text = "";
                fbrText2.text = "";
                fhrText3.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                fhrText4.text = "";
                ShowBlockRateTitle(true);
                break;
            case 5:
                //Paladin
                fhrText.text = "FHR Frames\n0% 9\n7% 8\n15% 7\n27% 6\n48% 5\n86% 4\n200% 3\n4680% 2";
                fcrText.text = "FCR Frames\n0% 15\n9% 14\n18% 13\n30% 12\n48% 11\n75% 10\n125% 9";
                fbrText.text = "Paladin (With Holy shield)\nFBR Frames\n0% 2\n86% 1";// Paladin (With Holy shield)
                fbrText2.text = "Paladin (Without Holy shield)\nFBR Frames\n0% 5\n13% 4\n32% 3\n86% 2\n600% 1";// Paladin (Without Holy shield)
                fhrText2.text = "";
                fcrText2.text = "";
                fhrText3.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                fhrText4.text = "";
                ShowBlockRateTitle(true);
                break;
            case 6:
                //Sorceress
                fhrText.text = "FHR Frames\n0% 15\n5% 14\n9% 13\n14% 12\n20% 11\n30% 10\n42% 9\n60% 8\n86 7\n142% 6\n280% 5\n1480% 4";
                fcrText.text = "FCR Frames\n0% 13\n9% 12\n20% 11\n37% 10\n63% 9\n105% 8\n200% 7";
                fcrText2.text = "(Lightning / Chainlightning)\nFCR Frames\n0% 19\n7% 18\n15% 17\n23% 16\n35% 15\n52% 14\n78% 13\n117% 12\n194% 11"; // Sorceress (Lightning / Chainlightning)
                fbrText.text = "FBR Frames\n0% 9\n7% 8\n15% 7\n27% 6\n48% 5\n86% 4\n200% 3\n4680% 2";
                fhrText2.text = "";
                fbrText2.text = "";
                fhrText3.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                fhrText4.text = "";
                ShowBlockRateTitle(true);
                break;
            case 7:
                ////Merc breakpoints 
                fhrText.text = "Act 1 Merc\nFHR Frames\n0% 11\n6% 10\n13% 9\n20% 8\n32% 7\n52% 6\n86% 5\n174% 4\n 600% 3";
                fhrText2.text = "Act 2 Merc\nFHR Frames\n0% 15\n5% 14\n9% 13\n14% 12\n20% 11\n30% 10\n42% 9\n60% 8\n86 7\n142% 6\n280% 5\n1480% 4";
                fhrText3.text = "Act 3 Merc\nFHR Frames\n0% 17\n5% 16\n8% 15\n13% 14\n18% 13\n24% 12\n32% 11\n46% 10\n63% 9\n86% 8\n133% 7\n232% 6\n600% 5";
                fhrText4.text = "Act 5 Merc\nFHR Frames\n0% 9\n7% 8\n15% 7\n27% 6\n48% 5\n86% 4\n200% 3\n4680% 2";
                fcrText.text = "Act 3 Merc\nFCR Frames\n0% 17\n8% 16\n15% 15\n26% 14\n39% 13\n58% 12\n86% 11\n138% 10";
                fbrText.text = "";
                fcrText2.text = "";
                fbrText2.text = "";
                fcrText3.text = "";
                fbrText3.text = "";
                ShowBlockRateTitle(false);
                break;
        }
    }
}
