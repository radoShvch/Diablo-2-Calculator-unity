using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NavigationTween : MonoBehaviour
{
    public GameObject NavigationPanel;
    private bool NavigationAlreadyOpen = false;
    public float moveX;
    public GameObject armoryNavHelper;
    public GameObject breakpointsNavHelper;
    public GameObject runesCounterNavHelper;
    public float moveY;
    private void Start()
    {
    }
    public void ShowBreakpoints()
    {
        ArmoryTweener();
        LeanTween.moveLocalX(runesCounterNavHelper, -708.0f, 0.1f);
        BreakpointsTweener();
    }
    public void ShowRunesCounter()
    {
        LeanTween.moveLocalX(armoryNavHelper, 378.0f, 0.1f);
        LeanTween.moveLocalX(breakpointsNavHelper, -378.0f, 0.1f);
        LeanTween.moveLocalX(runesCounterNavHelper, 0.0f, 0.1f);
    }

    public void HideBreakpoints()
    {
        LeanTween.moveLocalX(armoryNavHelper,0.0f, 0.1f);
        LeanTween.moveLocalX(breakpointsNavHelper, -378.0f, 0.1f);
        LeanTween.moveLocalX(runesCounterNavHelper, -708.0f, 0.1f);
    }
    public void ArmoryTweener()
    {
        LeanTween.moveLocalX(armoryNavHelper, 378.0f, 0.1f);
        LeanTween.moveLocalX(runesCounterNavHelper, -708.0f, 0.1f);
    }
    public void BreakpointsTweener()
    {
        LeanTween.moveLocalX(runesCounterNavHelper, -708.0f, 0.1f);
        LeanTween.moveLocalX(breakpointsNavHelper, 0.0f, 0.1f);
    }
    public void NavigationTweener()
    {
        LeanTween.moveLocalX(gameObject, -121.4371f, 0.1f);
        //NavigationAlreadyOpen = true;
    }
    public void NavigationDeTweener()
    {
        LeanTween.moveLocalX(gameObject, -161.4371f, 0.1f);
        //NavigationAlreadyOpen = false;
    }
    void ShowHideNavigation()
    {
        if (NavigationAlreadyOpen)
        {
            NavigationDeTweener();
            NavigationAlreadyOpen = false;
        }
        else
        {
            NavigationTweener();
            NavigationAlreadyOpen = true;
        }
    }
    
}
