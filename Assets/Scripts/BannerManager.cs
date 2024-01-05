using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ShowBanner();
    }
    public void ShowBanner() 
    {
        AdManager.ShowBanner();
    }
    public void HideBanner()
    {
        AdManager.HideBanner();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
